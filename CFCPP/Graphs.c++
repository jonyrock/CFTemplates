#include <stdio.h>
#include <string.h>
#include <iostream>
#include <algorithm>
#include <sstream>
#include <vector>
#include <stack>

using namespace std;

class Graph {

public:
    typedef vector<size_t> vset;

private:
    vector<vset> edges;
    vector<vset> redges;
    bool inReversedSide;
    vector<bool> lastDfsVisited;
    
    void checkVertexesRanges(size_t vetrtexIndex){
        if (edges.size() <= vetrtexIndex + 1) {
            edges.resize(vetrtexIndex + 1);
            redges.resize(vetrtexIndex + 1);
        }
    }

public:

    Graph(size_t prelim_size = 15):inReversedSide(true) {
        edges.resize(prelim_size + 1);
        redges.resize(prelim_size + 1);
    }

    void addEdge(size_t from, size_t to) {
        checkVertexesRanges(max(from, to));
        edges.at(from).push_back(to);
        redges.at(to).push_back(from);
    }

    void toggleReverseSide() {
        inReversedSide = !inReversedSide;
    }

    const vset& friendsFrom(size_t from) {
        checkVertexesRanges(from);
        if (inReversedSide)
            return edges.at(from);
        else
            return redges.at(from);
    }

    const vset& friendsTo(size_t to) {
        checkVertexesRanges(to);
        if (!inReversedSide)
            return edges.at(to);
        else
            return redges.at(to);
    }
    
    void dfs(size_t from, vector<size_t>& connected) {
        lastDfsVisited.resize(edges.size());
        stack<size_t> unexplored;
        unexplored.push(from);
        while (!unexplored.empty()) {
            size_t current = unexplored.top();
            if(lastDfsVisited.at(current)){ unexplored.pop(); continue; }
            lastDfsVisited[current] = true;
            connected.push_back(current);
            unexplored.pop();
            const vset& friends = friendsFrom(current);

            REP(i, friends.size()){
                size_t v = friends.at(i);
                if (lastDfsVisited[v]) continue;
                lastDfsVisited[v] = true;
                unexplored.push(v);
            }
        }
        
        REP(i, connected.size()) lastDfsVisited.at(connected.at(i)) = false; // remove if visits unique

    }
    
    vector<size_t> parent;
    size_t getParent(size_t vertex){
        if(parent.at(vertex) == vertex) return vertex;
        return parent[vertex] = getParent(parent[vertex]);
    }
    void buildSNP() {
        parent.resize(edges.size());
        for(size_t i = 0; i < edges.size(); i++){
            parent.at(i) = i;
        }
        for(vector<vset>::iterator it = edges.begin(); it != edges.end(); it++){
            for(vset::iterator jt = it->begin(); jt != it->end(); jt++){
                // v -- > u
                size_t v = it - edges.begin();
                size_t u = *jt;
                if(u==v) continue;
                parent[getParent(v)] = getParent(u);
            }
        }
        for(size_t i = 0; i < parent.size(); i++) getParent(i);
    }

};


