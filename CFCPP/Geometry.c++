template<class T>
struct point {
    T x, y;

    point() {
    }

    point(T x, T y) : x(x), y(y) {
    }

    bool operator==(const point<T>& p) const {
        return x == p.x && y == p.y;
    }
};

template<class T>
bool operator<(const point<T>& a, const point<T>& b) {
    if (a.x < b.x) return true;
    return a.y < b.y;
}

template<class T>
struct line {
    point<T> begin, end;

    line() {
    }

    line(T x1, T y1, T x2, T y2) : begin(x1, y1), end(x2, y2) {
    }

    line(point<T> begin, point<T> end) : begin(begin), end(end) {
    }

    bool operator==(const line<T>& l) const {
        return begin == l.begin && end == l.end ||
                end == l.begin && begin == l.end;
    }
};

template<class T>
bool operator<(const line<T>& a, const line<T>& b) {
    if (a.begin < b.begin) return true;
    return a.end < b.end;
}
