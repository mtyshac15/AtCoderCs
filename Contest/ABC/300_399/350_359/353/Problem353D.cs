using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC353;

public class ProblemD
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var cons = 998244353;
        ModInt.Init(cons);

        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();

        //累積和
        var s = new ModInt[N + 1];
        for (var i = 0; i < N; i++)
        {
            s[i + 1] = s[i] + A[i];
        }

        //桁数
        var digits = new int[10];
        for (var i = 0; i < N; i++)
        {
            var index = A[i].ToString().Length;
            digits[index - 1]++;
        }

        var p10 = new ModInt[10];
        p10[0] = 10;
        for (var i = 0; i < 9; i++)
        {
            p10[i + 1] = p10[i] * 10;
        }

        ModInt ans = 0;

        for (int i = 0; i < N - 1; i++)
        {
            digits[A[i].ToString().Length - 1]--;

            ModInt sum = 0;
            for (int j = 0; j < 10; j++)
            {
                sum += p10[j] * A[i] * (ModInt)digits[j];
            }

            var tmp = sum + s[N] - s[i + 1];
            ans += tmp;
        }

        _writer.WriteLine(ans);
    }

    public struct ModInt : IEquatable<ModInt>
    {
        public const int MOD = 1000000007;
        private static int m = ModInt.MOD;

        private int value;

        private static IList<long> facList;
        private static IList<long> facInvList;
        private static IList<long> invList;

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
            return (long)a.value * b.value;
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

        #region 
        public static void Init(int m = ModInt.MOD)
        {
            ModInt.m = m;
            ModInt.CombinationInit();
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

        public static void CombinationInit()
        {
            var max = 510000;
            ModInt.facList = new long[max];
            ModInt.facList[0] = 1;
            ModInt.facList[1] = 1;

            ModInt.facInvList = new long[max];
            ModInt.facInvList[0] = 1;
            ModInt.facInvList[1] = 1;

            ModInt.invList = new long[max];
            ModInt.invList[1] = 1;

            for (int i = 2; i < max; i++)
            {
                ModInt.facList[i] = ModInt.facList[i - 1] * i % ModInt.m;
                ModInt.invList[i] = ModInt.m - ModInt.invList[ModInt.m % i] * (ModInt.m / i) % ModInt.m;
                ModInt.facInvList[i] = ModInt.facInvList[i - 1] * ModInt.invList[i] % ModInt.m;
            }
        }

        public static ModInt Combination(ModInt n, ModInt k)
        {
            if (n < k)
            {
                return 0;
            }

            return ModInt.facList[n.ToInt()] * (ModInt.facInvList[k.ToInt()] * ModInt.facInvList[(n - k).ToInt()] % ModInt.m);
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

        public int ToInt()
        {
            return this.value;
        }

        public override string ToString()
        {
            return $"{this.value}";
        }
        #endregion
    }
}
