using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC361;

public class ProblemE
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemE();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemE()
        : this(Console.In, Console.Out)
    {
    }

    public ProblemE(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var N = _reader.NextLong();
        var K = _reader.NextInt();

        var mod = 998244353;
        ModInt.Init(mod);

        var r = new ModInt(N - 2) / N;
        r = r.Pow(K);

        //x = 1のとき
        var p1 = new ModInt(N - 1) / N;
        p1 *= r;
        p1 += new ModInt(1) / N;

        //x ≠ 1のとき
        var px = new ModInt(-1) / N;
        px *= r;
        px += new ModInt(1) / N;

        var total = new ModInt(N) * (N + 1) / 2 - 1;
        var ans = p1 * 1 + px * total;

        _writer.WriteLine(ans);
    }

    #region ""
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
            return EqualityComparer<int>.Default.GetHashCode(this.value);
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
    #endregion

    #region "IO"
    public class Reader
    {
        private TextReader _reader;
        private int _index;
        private string[] _line;

        private char[] _cs = new char[] { ' ' };

        public Reader(TextReader reader)
        {
            _reader = reader;
            _index = 0;
            _line = new string[0];
        }

        private string NextLine()
        {
            return _reader.ReadLine().Trim();
        }

        public string Next()
        {
            if (_index < _line.Length)
            {
                return _line[_index++];
            }

            _line = this.NextArray();
            if (!_line.Any())
            {
                return this.Next();
            }

            _index = 0;
            return _line[_index++];
        }

        public int NextInt()
        {
            return int.Parse(this.Next());
        }

        public long NextLong()
        {
            return long.Parse(this.Next());
        }

        public string[] NextArray()
        {
            return this.NextLine().Split(_cs, StringSplitOptions.RemoveEmptyEntries);
        }

        public int[] NextIntArray()
        {
            return this.NextArray().Select(int.Parse).ToArray();
        }
    }

    class Writer
    {
        private TextWriter _writer;

        public Writer(TextWriter writer)
        {
            _writer = writer;
        }

        public void WriteLine(object value = null)
        {
            _writer.WriteLine(value);
        }

        public void WriteYesOrNo(bool value)
        {
            this.WriteLine(Writer.ToYesOrNo(value));
        }

        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
    #endregion
}
