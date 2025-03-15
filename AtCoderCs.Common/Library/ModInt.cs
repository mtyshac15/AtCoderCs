using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderCs.Common.Library;

public struct ModInt : IEquatable<ModInt>
{
    //public const int MOD = 1000000007;
    public const int MOD = 998244353;
    private static int _m = ModInt.MOD;

    private static IList<long> _facList = new List<long>();
    private static IList<long> _facInvList = new List<long>();
    private static IList<long> _invList = new List<long>();

    private int _value;

    public ModInt(int value)
        : this((long)value)
    {
    }

    public ModInt(long value)
    {
        var tmpX = value;
        while (tmpX < 0)
        {
            tmpX += _m;
        }
        var x = (int)(tmpX % _m);
        _value = x;
    }

    #region
    public static implicit operator ModInt(int value)
    {
        return new ModInt(value);
    }

    public static implicit operator ModInt(long value)
    {
        return new ModInt(value);
    }

    public static ModInt operator +(ModInt a)
    {
        return a._value;
    }

    public static ModInt operator -(ModInt a)
    {
        return -a._value;
    }

    public static ModInt operator ++(ModInt a)
    {
        return a + 1;
    }

    public static ModInt operator --(ModInt a)
    {
        return a - 1;
    }

    public static ModInt operator +(ModInt a, ModInt b)
    {
        return a._value + b._value;
    }

    public static ModInt operator -(ModInt a, ModInt b)
    {
        return a + (-b);
    }

    public static ModInt operator *(ModInt a, ModInt b)
    {
        return (long)a._value * b._value;
    }

    public static ModInt operator /(ModInt a, ModInt b)
    {
        return a * b.Inverse();
    }

    public static bool operator <(ModInt a, ModInt b)
    {
        return a._value < b._value;
    }

    public static bool operator >(ModInt a, ModInt b)
    {
        return a._value > b._value;
    }

    public static bool operator <=(ModInt a, ModInt b)
    {
        return a == b || a < b;
    }

    public static bool operator >=(ModInt a, ModInt b)
    {
        return a == b || a > b;
    }

    public static bool operator ==(ModInt a, ModInt b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(ModInt a, ModInt b)
    {
        return !(a == b);
    }
    #endregion

    public static ModInt Max
    {
        get { return _m - 1; }
    }

    #region
    public static void Init(int m = ModInt.MOD)
    {
        _m = m;
        CombinationInit();
    }

    /// <summary>
    /// a^n (mod m)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static ModInt Pow(ModInt a, long n)
    {
        ModInt ans = 1;

        var basis = a;
        var tmpN = n;

        while (tmpN > 0)
        {
            if ((tmpN & 1) > 0)
            {
                ans *= basis;
            }

            basis *= basis;
            tmpN >>= 1;
        }

        return ans;
    }

    /// <summary>
    /// 階乗
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static ModInt Factorial(ModInt n)
    {
        return ModInt.Permutation(n, n);
    }

    /// <summary>
    /// 順列
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static ModInt Permutation(ModInt n, ModInt k)
    {
        ModInt ans = 1;
        for (var i = n; i >= n - k + 1; i--)
        {
            ans *= i;
        }
        return ans;
    }

    /// <summary>
    /// 組合せの初期化
    /// </summary>
    public static void CombinationInit()
    {
        var max = 510000;
        _facList = new long[max];
        _facList[0] = 1;
        _facList[1] = 1;

        _facInvList = new long[max];
        _facInvList[0] = 1;
        _facInvList[1] = 1;

        _invList = new long[max];
        _invList[1] = 1;

        for (int i = 2; i < max; i++)
        {
            _facList[i] = _facList[i - 1] * i % _m;
            _invList[i] = _m - _invList[_m % i] * (_m / i) % _m;
            _facInvList[i] = _facInvList[i - 1] * _invList[i] % _m;
        }
    }

    /// <summary>
    /// 組合せ
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static ModInt Combination(ModInt n, ModInt k)
    {
        if (n < k)
        {
            return 0;
        }

        return _facList[n.ToInt()] * (_facInvList[k.ToInt()] * _facInvList[(n - k).ToInt()] % _m);
    }

    /// <summary>
    /// 逆元
    /// </summary>
    /// <param name="modInt"></param>
    /// <returns></returns>
    public static ModInt Inverse(ModInt modInt)
    {
        try
        {
            var a = modInt._value;
            var b = _m;

            ModInt x0 = 1;
            ModInt x1 = 0;

            while (b != 1)
            {
                var r = a % b;
                var q = a / b;

                var tmpX = x0 - q * x1;
                x0 = x1;
                x1 = tmpX;

                a = b;
                b = r;
            }
            return x1;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region 
    /// <summary>
    /// べき乗
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public ModInt Pow(long n)
    {
        return ModInt.Pow(this, n);
    }

    /// <summary>
    /// 逆元
    /// </summary>
    /// <returns></returns>
    public ModInt Inverse()
    {
        return ModInt.Inverse(this);
    }

    public int ToInt()
    {
        return this._value;
    }

    public override int GetHashCode()
    {
        return EqualityComparer<int>.Default.GetHashCode(_value);
    }

    public bool Equals(ModInt other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is ModInt))
        {
            return false;
        }

        return this.Equals((ModInt)obj);
    }

    public override string ToString()
    {
        return $"{_value}";
    }
    #endregion

}