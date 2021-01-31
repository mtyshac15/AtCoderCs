using System;
using System.Collections.Generic;
using System.Linq;

public struct ModInt : IEquatable<ModInt>
{
    public const int MOD = 1000000007;
    private static int m = ModInt.MOD;

    private int value;

    public ModInt(int value)
        : this((long)value)
    {
    }

    public ModInt(long value)
        : this()
    {
        var tmpX = value;
        while (tmpX < 0)
        {
            tmpX += ModInt.m;
        }
        var x = (int)(tmpX % ModInt.m);
        this.value = x;
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
        return a.value;
    }

    public static ModInt operator -(ModInt a)
    {
        return -a.value;
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
        return a.value + b.value;
    }

    public static ModInt operator -(ModInt a, ModInt b)
    {
        return a + (-b);
    }

    public static ModInt operator *(ModInt a, ModInt b)
    {
        return a.value * b.value;
    }

    public static ModInt operator /(ModInt a, ModInt b)
    {
        return a * b.Inverse();
    }

    public static bool operator <(ModInt a, ModInt b)
    {
        return a.value < b.value;
    }

    public static bool operator >(ModInt a, ModInt b)
    {
        return a.value > b.value;
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
        get
        {
            return ModInt.m - 1;
        }
    }


    public int Value
    {
        get
        {
            return this.value;
        }
    }

    #region 

    public static void Init(int m)
    {
        ModInt.m = m;
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

        var tmpA = a;
        var tmpN = n;

        while (tmpN > 0)
        {
            if ((tmpN & 1) == 1)
            {
                ans *= tmpA;
            }

            tmpA *= tmpA;
            tmpN >>= 1;
        }

        return ans;
    }

    public ModInt Pow(long n)
    {
        return ModInt.Pow(this, n);
    }

    public static ModInt Factorial(ModInt n)
    {
        return ModInt.Permutation(n, n);
    }

    public static ModInt Permutation(ModInt n, ModInt k)
    {
        ModInt ans = 1;
        for (var i = n; i >= n - k + 1; i--)
        {
            ans *= i;
        }
        return ans;
    }

    public static ModInt Combination(ModInt n, ModInt k)
    {
        return ModInt.Permutation(n, k) / ModInt.Factorial(k);
    }

    /// <summary>
    /// 逆元
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static ModInt Inverse(ModInt modInt)
    {
        try
        {
            var a = modInt.value;
            var b = ModInt.m;

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

    public ModInt Inverse()
    {
        return ModInt.Inverse(this);
    }

    public bool Equals(ModInt other)
    {
        return this.value == other.value;
    }


    public override bool Equals(object obj)
    {
        if (!(obj is ModInt))
        {
            return false;
        }

        return this.Equals((ModInt)obj);
    }

    public override int GetHashCode()
    {
        return this.value;
    }

    public override string ToString()
    {
        return $"{this.value}";
    }

    #endregion
}