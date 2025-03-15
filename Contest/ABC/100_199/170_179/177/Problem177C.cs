using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC177;

public class ProblemC
{
    private Reader _reader;
    private Writer _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC(Console.In, Console.Out);
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC(TextReader textReader, TextWriter textWriter)
    {
        _reader = new Reader(textReader);
        _writer = new Writer(textWriter);
    }

    public void Solve()
    {
        var mod = 1_000_000_000 + 7;
        ModInt.Init(mod);

        var N = _reader.NextInt();
        var A = _reader.NextIntArray();

        var sumA = new ModInt[N + 1];
        for (int i = 0; i < A.Length; i++)
        {
            sumA[i + 1] = sumA[i] + A[i];
        }

        var sum = (ModInt)0;
        for (int i = 0; i < N; i++)
        {
            sum += A[i] * (sumA[sumA.Length - 1] - sumA[i + 1]);
        }

        var ans = sum;
        _writer.WriteLine(ans);
    }

    #region
    struct ModInt : IEquatable<ModInt>
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
        /// äKèÊ
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ModInt Factorial(ModInt n)
        {
            return ModInt.Permutation(n, n);
        }

        /// <summary>
        /// èáóÒ
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
        /// ëgçáÇπÇÃèâä˙âª
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
        /// ëgçáÇπ
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
        /// ãtå≥
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
        /// Ç◊Ç´èÊ
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public ModInt Pow(long n)
        {
            return ModInt.Pow(this, n);
        }

        /// <summary>
        /// ãtå≥
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

    class Reader
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

        public long[] NextLongArray()
        {
            return this.NextArray().Select(long.Parse).ToArray();
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
