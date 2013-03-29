class SegmentsTree {
    int* tree;
    size_t n;
    int* begin_;

public:

    SegmentsTree(int* begin, int* end) : begin_(begin) {
        n = end - begin;
        tree = new int[n * 4 + 1];
        build(1, 0, n - 1);
    }

    int getMax(int* begin, int* end) {
        if (begin == end) return 0;
        return getMax(1, 0, n - 1, begin - begin_, end - begin_ - 1);
    }

    void update(int* pos) {
        update(1, 0, n - 1, pos - begin_);
    }

    ~SegmentsTree() {
        //delete[] tree;
    }
    
private:
    void build(size_t v, size_t tl, size_t tr) {
        if (tl == tr) {
            tree[v] = begin_[tl];
            return;
        }
        size_t tm = (tl + tr) / 2;
        build(2 * v, tl, tm);
        build(2 * v + 1, tm + 1, tr);
        tree[v] = max(tree[2 * v], tree[2 * v + 1]);
    }

    int getMax(size_t v, size_t tl, size_t tr, size_t l, size_t r) const {
        if (l > r) return 0;
        if (tl == l && tr == r) return tree[v];
        size_t tm = (tl + tr) / 2;
        int leftMax = getMax(2 * v, tl, tm, l, min(tm, r));
        int rightMax = getMax(2 * v + 1, tm + 1, tr, max(tm + 1, l), r);
        return max(leftMax, rightMax);
    }
    
    void update(size_t v, size_t tl, size_t tr, size_t pos){
        if(tl==tr){
            tree[v] = begin_[pos];
            return;
        }
        size_t tm = (tl + tr) / 2;
        if(pos <= tm)
            update(2*v, tl, tm, pos);
        else
            update(2*v+1, tm+1, tr, pos);
        tree[v] = max(tree[2 * v], tree[2 * v + 1]);
    }

};
