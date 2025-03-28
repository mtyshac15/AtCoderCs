namespace AtCoderCs.Common.Library;

public struct UnionFind
{
    IList<int> _par;
    IList<int> _size;

    public UnionFind(int n)
    {
        _par = Enumerable.Repeat(-1, n + 1).ToList();
        _size = Enumerable.Repeat(1, n + 1).ToList();
    }

    /// <summary>
    /// 根を求める
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int Root(int x)
    {
        if (_par[x] == -1)
        {
            return x;
        }
        else
        {
            _par[x] = this.Root(_par[x]);
            return _par[x];
        }
    }

    /// <summary>
    /// xとyが同じグループの所属するか
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool IsSame(int x, int y)
    {
        return this.Root(x) == this.Root(y);
    }

    public bool Unite(int x, int y)
    {
        //x,yの親を取得
        var rootX = this.Root(x);
        var rootY = this.Root(y);

        if (rootX == rootY)
        {
            return false;
        }

        if (_size[rootX] < _size[rootY])
        {
            var temp = rootX;
            rootX = rootY;
            rootY = temp;
        }

        _par[rootY] = rootX;
        _size[rootX] += _size[rootY];
        return true;
    }

    public int Size(int x)
    {
        return _size[this.Root(x)];
    }
}
