using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Problem : ProblemBase
{
    public static void Main(string[] args)
    {
        var problem = new Problem();
        problem.SolveD();
    }

    private struct Edge
    {
        public Edge(int to, long cost)
        {
            this.To = to;
            this.Cost = cost;
        }

        public int To { get; }

        public long Cost { get; }
    }

    public override void SolveD()
    {
        var (N, M, T) = IOLibrary.ReadInt3();
        var A = IOLibrary.ReadIntArray();

        //隣接リストを作成
        var graph = new List<Edge>[N];
        var reverseGraph = new List<Edge>[N];
        for (int i = 0; i < N; i++)
        {
            graph[i] = new List<Edge>();
            reverseGraph[i] = new List<Edge>();
        }

        for (int i = 0; i < M; i++)
        {
            var (a, b, c) = IOLibrary.ReadInt3();
            graph[a - 1].Add(new Edge(b - 1, c));

            //逆向きのグラフ
            reverseGraph[b - 1].Add(new Edge(a - 1, c));
        }

        //1からkへの最短時間
        var toArray = this.Dijkstra(graph, 0);

        //iから1への最短時間
        var fromArray = this.Dijkstra(reverseGraph, 0);

        var ans = 0L;
        for (int i = 0; i < N; i++)
        {
            var time = T - toArray[i] - fromArray[i];
            if (time >= 0)
            {
                var gold = A[i] * time;
                ans = Math.Max(gold, ans);
            }
        }

        IOLibrary.WriteLine(ans);
    }

    private IList<long> Dijkstra(IList<IList<Edge>> graph, int startIndex)
    {
        var n = graph.Count;
        var toArray = Enumerable.Repeat(long.MaxValue, n).ToArray();

        //最短時間が確定したノード
        var used = new bool[n];

        var currentIndex = startIndex;
        used[currentIndex] = true;
        toArray[currentIndex] = 0;

        while (used.Any(flag => !flag))
        {
            foreach (var edge in graph[currentIndex])
            {
                var cost = toArray[currentIndex] + edge.Cost;
                toArray[edge.To] = Math.Min(cost, toArray[edge.To]);
            }

            //最小のノードを探索
            var minNode = -1;
            var minCost = long.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (!used[i] && toArray[i] < minCost)
                {
                    minNode = i;
                    minCost = toArray[i];
                }
            }

            //探索済みに追加
            if (minNode == -1)
            {
                break;
            }

            used[minNode] = true;
            currentIndex = minNode;
        }

        return toArray;
    }
}

#region "Library"

public class IOLibrary
{
    public IOLibrary()
    {
    }

    #region "Method"

    private static Func<string> ReadMethod { get; set; } = Console.ReadLine;

    private static Action<object> WriteMethod { get; set; } = Console.WriteLine;


    public static void SetReadLineMethod(Func<string> readLine)
    {
        IOLibrary.ReadMethod = readLine;
    }

    public static void SetWriteLineMethod(Action<object> writeLine)
    {
        IOLibrary.WriteMethod = writeLine;
    }

    #region "string"

    public static string ReadLine()
    {
        return IOLibrary.ReadMethod();
    }

    public static string[] ReadStringArray()
    {
        return IOLibrary.ReadLine().Trim().Split(' ');
    }

    public static string[] ReadStringArray(int row)
    {
        var array = new string[row];
        for (var i = 0; i < row; i++)
        {
            array[i] = IOLibrary.ReadLine();
        }
        return array;
    }

    public static string[,] ReadStringArray(int row, int col)
    {
        var array = new string[row, col];
        for (var i = 0; i < row; i++)
        {
            var line = IOLibrary.ReadLine();
            for (var j = 0; j < col; j++)
            {
                array[i, j] = line[j].ToString();
            }
        }
        return array;
    }

    public static Matrix GetMatrix(int rowCount, int colCount)
    {
        var matrix = new Matrix(rowCount, colCount);

        for (var row = 0; row < rowCount; row++)
        {
            var rows = IOLibrary.ReadLongArray();
            matrix.Init(row, rows);
        }

        return matrix;
    }

    #endregion

    #region "int"

    public static int ReadInt()
    {
        return int.Parse(IOLibrary.ReadLine());
    }

    public static (int, int) ReadInt2()
    {
        var inputs = IOLibrary.ReadIntArray();
        return (inputs[0], inputs[1]);
    }

    public static (int, int, int) ReadInt3()
    {
        var inputs = IOLibrary.ReadIntArray();
        return (inputs[0], inputs[1], inputs[2]);
    }

    public static (int, int, int, int) ReadInt4()
    {
        var inputs = IOLibrary.ReadIntArray();
        return (inputs[0], inputs[1], inputs[2], inputs[3]);
    }

    public static int[] ReadIntArray()
    {
        return IOLibrary.ReadStringArray()
                        .Select(item => int.Parse(item))
                        .ToArray();
    }

    public static int[] ReadIntArray(int row)
    {
        var array = new int[row];
        for (var i = 0; i < row; i++)
        {
            array[i] = IOLibrary.ReadInt();
        }
        return array;
    }

    public static int[][] ReadInt2DArray(int size)
    {
        var array = new int[size][];
        for (var i = 0; i < size; i++)
        {
            array[i] = IOLibrary.ReadIntArray();
        }
        return array;
    }

    public static int[,] ReadInt2DArray(int row, int col)
    {
        var array = new int[row, col];
        for (var i = 0; i < row; i++)
        {
            var line = IOLibrary.ReadIntArray();
            for (var j = 0; j < col; j++)
            {
                array[i, j] = line[j];
            }
        }
        return array;
    }

    #endregion

    #region "long"

    public static long ReadLong()
    {
        return long.Parse(IOLibrary.ReadLine());
    }

    public static (long, long) ReadLong2()
    {
        var inputs = IOLibrary.ReadLongArray();
        return (inputs[0], inputs[1]);
    }

    public static (long, long, long) ReadLong3()
    {
        var inputs = IOLibrary.ReadLongArray();
        return (inputs[0], inputs[1], inputs[2]);
    }

    public static (long, long, long, long) ReadLong4()
    {
        var inputs = IOLibrary.ReadLongArray();
        return (inputs[0], inputs[1], inputs[1], inputs[3]);
    }

    public static long[] ReadLongArray()
    {
        return IOLibrary.ReadStringArray()
                        .Select(item => long.Parse(item))
                        .ToArray();
    }

    public static long[] ReadLongArray(long row)
    {
        var array = new long[row];
        for (var i = 0; i < row; i++)
        {
            array[i] = IOLibrary.ReadLong();
        }
        return array;
    }

    public static long[][] ReadLong2DArray(long size)
    {
        var array = new long[size][];
        for (var i = 0; i < size; i++)
        {
            array[i] = IOLibrary.ReadLongArray();
        }
        return array;
    }

    public static long[,] ReadLong2DArray(long row, long col)
    {
        var array = new long[row, col];
        for (var i = 0; i < row; i++)
        {
            var line = IOLibrary.ReadLongArray();
            for (var j = 0; j < col; j++)
            {
                array[i, j] = line[j];
            }
        }
        return array;
    }

    #endregion

    public static ModInt[] ReadModIntArray(int mod)
    {
        ModInt.Init(mod);
        return IOLibrary.ReadModIntArray();
    }

    public static ModInt[] ReadModIntArray()
    {
        return IOLibrary.ReadStringArray()
                        .Select(item => (ModInt)int.Parse(item))
                        .ToArray();
    }

    #endregion

    #region "Output"

    public static void WriteLine(object value = null)
    {
        var sw = new StreamWriter(Console.OpenStandardOutput())
        {
            AutoFlush = false
        };

        Console.SetOut(sw);
        IOLibrary.WriteMethod(value);
        Console.Out.Flush();
    }

    public static void OutputList<T>(IEnumerable<T> list)
    {
        var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
        Console.SetOut(sw);
        foreach (var value in list)
        {
            IOLibrary.WriteMethod(value);
        }
        Console.Out.Flush();
    }

    public static void WriteYesOrNo(bool value)
    {
        IOLibrary.WriteLine(IOLibrary.ToYesOrNo(value));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }

    public static T DeepClone<T>(T source)
    {
        var jsonString = System.Text.Json.JsonSerializer.Serialize(source);
        var clone = System.Text.Json.JsonSerializer.Deserialize<T>(jsonString);
        return clone;
    }

    #endregion
}

public static class MathLibrary
{
    #region "約数、素数"

    /// <summary>
    /// 約数を列挙
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<long> GetDivisorList(long n)
    {
        for (var i = 1L; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                yield return i;

                var quotient = n / i;
                if (quotient != i)
                {
                    yield return quotient;
                }
            }
        }
    }

    /// <summary>
    /// 約数を列挙
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IList<long> GetDivisorSortedList(long n)
    {
        var list = new List<long>(MathLibrary.GetDivisorList(n));
        list.Sort();
        return list;
    }

    /// <summary>
    /// 約数の前半部分を列挙
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<long> GetDivisorHarfList(long n)
    {
        for (long i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                yield return i;
            }
        }
    }

    /// <summary>
    /// 素数判定
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPrime(long n)
    {
        for (long i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 素因数分解
    /// </summary>
    public static IList<IList<long>> PrimeFactorizationSet(long n)
    {
        var testN = n;
        var array = new List<IList<long>>();
        for (long i = 2; ; i++)
        {
            if (MathLibrary.IsPrime(i))
            {
                var count = 0;
                var elements = new List<long>();

                while (testN % i == 0)
                {
                    testN /= i;
                    count++;
                }

                if (count > 0)
                {
                    //素因数と指数部の組
                    elements.Add(i);
                    elements.Add(count);
                    array.Add(elements);
                }

                if (testN == 1)
                {
                    break;
                }
            }
        }

        return array;
    }

    public static IList<long> PrimeFactorization(long n)
    {
        var testN = n;
        var array = new List<long>();
        for (long i = 2; ; i++)
        {
            if (MathLibrary.IsPrime(i))
            {
                while (testN % i == 0)
                {
                    array.Add(i);
                    testN /= i;
                }

                if (testN == 1)
                {
                    break;
                }
            }
        }

        return array;
    }

    #region "最大公約数"

    /// <summary>
    /// 最大公約数
    /// </summary>
    /// <returns></returns>
    public static int GCD(IEnumerable<int> collection)
    {
        //0を除く
        var newCollection = collection.Where(x => x != 0);
        var ans = newCollection.FirstOrDefault();
        foreach (var item in newCollection)
        {
            ans = MathLibrary.GCD(ans, item);
        }
        return ans;
    }

    public static int GCD(params int[] collection)
    {
        return MathLibrary.GCD((IEnumerable<int>)collection);
    }

    /// <summary>
    /// 最大公約数
    /// </summary>
    /// <returns></returns>
    public static int GCD(int a, int b)
    {
        if (a % b == 0)
        {
            return b;
        }

        return MathLibrary.GCD(b, a % b);
    }

    /// <summary>
    /// 最大公約数
    /// </summary>
    /// <returns></returns>
    public static long GCD(IEnumerable<long> collection)
    {
        //0を除く
        var newCollection = collection.Where(x => x != 0);
        var ans = newCollection.FirstOrDefault();
        foreach (var item in newCollection)
        {
            ans = MathLibrary.GCD(ans, item);
        }
        return ans;
    }

    public static long GCD(params long[] collection)
    {
        return MathLibrary.GCD((IEnumerable<long>)collection);
    }

    /// <summary>
    /// 最大公約数
    /// </summary>
    /// <returns></returns>
    public static long GCD(long a, long b)
    {
        if (a % b == 0)
        {
            return b;
        }

        return MathLibrary.GCD(b, a % b);
    }

    #endregion

    #region "最小公倍数"

    /// <summary>
    /// 最小公倍数
    /// </summary>
    /// <returns></returns>
    public static int LCM(IEnumerable<int> collection)
    {
        var ans = collection.FirstOrDefault();
        foreach (var item in collection)
        {
            ans = MathLibrary.LCM(ans, item);
        }
        return ans;
    }

    /// <summary>
    /// 最小公倍数
    /// </summary>
    /// <returns></returns>
    public static int LCM(int a, int b)
    {
        var gcd = MathLibrary.GCD(a, b);
        return a / gcd * b;
    }

    /// <summary>
    /// 最小公倍数
    /// </summary>
    /// <returns></returns>
    public static long LCM(IEnumerable<long> collection)
    {
        var ans = collection.FirstOrDefault();
        foreach (var item in collection)
        {
            ans = MathLibrary.LCM(ans, item);
        }
        return ans;
    }

    /// <summary>
    /// 最小公倍数
    /// </summary>
    /// <returns></returns>
    public static long LCM(long a, long b)
    {
        var gcd = MathLibrary.GCD(a, b);
        return a / gcd * b;
    }

    #endregion

    #endregion

    #region ""

    /// <summary>
    /// 桁数
    /// </summary>
    /// <param name="num"></param>
    /// <param name="basis"></param>
    /// <returns></returns>
    public static int Digits(this long num, long basis = 10)
    {
        var testNum = num;
        var digit = 0;
        do
        {
            testNum /= basis;
            digit++;
        } while (testNum > 0);
        return digit;
    }

    public static int Digits(this long num, int n, int basis = 10)
    {
        return (int)(num / MathLibrary.Pow(basis, n - 1)) % basis;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static long Pow(long a, int n)
    {
        var ans = 1L;

        var basis = a;
        var tmpN = n;

        while (tmpN > 0)
        {
            if (MathLibrary.TestBit(tmpN, 0))
            {
                ans *= basis;
            }

            basis *= basis;
            tmpN >>= 1;
        }

        return ans;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="a">底</param>
    /// <returns></returns>
    public static int Log(long n, int a)
    {
        var count = 0;

        var value = n;
        while (value > 1)
        {
            value /= a;
            count++;
        }

        return count;
    }

    /// <summary>
    /// 各桁の和
    /// </summary>
    /// <returns></returns>
    public static int SumOfDigits(int num, int basis = 10)
    {
        var testNum = num;
        var sum = 0;
        while (testNum > 0)
        {
            sum += testNum % basis;
            testNum /= basis;
        }
        return sum;
    }

    /// <summary>
    /// 8進数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string ToOct(this long num)
    {
        var ans = "";
        var testNum = num;
        do
        {
            ans += (testNum % 8).ToString() + ans;
            testNum /= 8;
        } while (testNum > 0);

        return ans;
    }

    /// <summary>
    /// 16進数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string ToHex(this long num)
    {
        return num.ToString("x");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="num"></param>
    /// <param name="basis"></param>
    /// <returns></returns>
    public static IList<long> ConvertBasis(long num, long basis)
    {
        var list = new List<long>();

        var testNum = num;
        do
        {
            var d = testNum % basis;
            list.Add(d);
            testNum /= basis;
        } while (testNum > 0);

        return list;
    }

    /// <summary>
    /// 指定したビットが1かどうか
    /// </summary>
    /// <param name="source"></param>
    /// <param name="bit"></param>
    /// <returns></returns>
    public static bool TestBit(int source, int bit)
    {
        return (source & (1 << bit)) > 0;
    }

    public static int BitCount(int i)
    {
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        i = (i + (i >> 4)) & 0x0f0f0f0f;
        i = i + (i >> 8);
        i = i + (i >> 16);
        return i & 0x3f;
    }

    public static long Ceiling(long value, long basis = 1)
    {
        return (long)Math.Ceiling((double)value / basis) * basis;
    }

    public static long Floor(long value, long basis = 1)
    {
        return (long)Math.Floor((double)value / basis) * basis;
    }

    public static IList<IList<int>> GetGraph(long N)
    {
        //隣接リストを作成
        var graph = new List<IList<int>>();
        for (int i = 0; i < N; i++)
        {
            graph.Add(new List<int>());
        }
        return graph;
    }

    #endregion

    #region "順列 組合せ"

    /// <summary>
    /// 階乗
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static long Factorial(int n)
    {
        return MathLibrary.Permutation(n, n);
    }

    /// <summary>
    /// 順列
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static long Permutation(int n, int k)
    {
        var ans = 1L;
        for (var i = n; i >= n - k + 1; i--)
        {
            ans *= i;
        }
        return ans;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int[] GetSubsetFromBits(int n)
    {
        var digits = MathLibrary.Digits(n, 2);
        var array = new int[digits];

        for (var i = 0; i < digits; i++)
        {
            if (MathLibrary.TestBit(n, 1 << i))
            {
                array[i] = i;
            }
        }
        return array;
    }

    /// <summary>
    /// 組合せ
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static long Combination(int n, int k)
    {
        var ans = 1L;
        var molecule = n;
        for (var i = 1; i <= k; i++)
        {
            ans *= molecule;
            ans /= i;
            molecule--;
        }
        return ans;
    }

    /// <summary>
    /// 順列
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IEnumerable<int[]> GetPermutationIndex(IEnumerable<int> collection)
    {
        if (collection.Count() == 1)
        {
            yield return new int[] { collection.First() };
            yield break;
        }

        foreach (var item in collection)
        {
            var searchedArray = new int[] { item };
            var unsearchedArray = collection.Except(searchedArray).ToArray();

            var array = MathLibrary.GetPermutationIndex(unsearchedArray);
            foreach (var searchedItem in array)
            {
                yield return searchedArray.Concat(searchedItem).ToArray();
            }
        }
    }

    /// <summary>
    /// 順列
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IEnumerable<IList<int>> AllPermutation(int n)
    {
        var array = Enumerable.Range(0, n).ToArray();
        return MathLibrary.AllPermutation(array);
    }

    /// <summary>
    /// 順列を列挙
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IEnumerable<IList<T>> AllPermutation<T>(T[] array)
           where T : IComparable<T>
    {
        var list = new List<IList<T>>();

        do
        {
            T[] copy = new T[array.Length];
            array.CopyTo(copy, 0);
            list.Add(copy);
        }
        while (MathLibrary.NextPermutation(array));

        return list;
    }

    public static bool NextPermutation<T>(T[] array)
        where T : IComparable<T>
    {
        var isOk = false;

        //array[i]<array[i+1]を満たす最大のiを求める
        var i = array.Length - 2;
        for (; i >= 0; i--)
        {
            if (array[i].CompareTo(array[i + 1]) < 0)
            {
                isOk = true;
                break;
            }
        }

        //全ての要素が降順の場合終了
        if (!isOk)
        {
            return false;
        }

        //array[i]<array[j]を満たす最大のjを求める
        int j = array.Length - 1;
        for (; ; j--)
        {
            if (array[i].CompareTo(array[j]) < 0)
            {
                break;
            }
        }

        //iの要素とjの要素を交換
        var tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;

        //i以降の要素を反転させる
        Array.Reverse(array, i + 1, array.Length - (i + 1));

        return true;
    }

    /// <summary>
    /// 組合せを列挙
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IEnumerable<int[]> GetCombinationIndexCollection(int n, int k)
    {
        return MathLibrary.GetCombinationIndexCollection(Enumerable.Range(0, n), k);
    }

    public static IEnumerable<int[]> GetCombinationIndexCollection(IEnumerable<int> collection, int k)
    {
        if (k == 1)
        {
            foreach (var item in collection)
            {
                yield return new int[] { item };
            }
            yield break;
        }

        foreach (var item in collection)
        {
            var searchedArray = new int[] { item };
            var unsearchedArray = collection.SkipWhile(x => !x.Equals(item)).Skip(1).ToArray();
            foreach (var searchedItem in MathLibrary.GetCombinationIndexCollection(unsearchedArray, k - 1))
            {
                yield return searchedArray.Concat(searchedItem).ToArray();
            }
        }
    }

    /// <summary>
    /// 重複組合せを列挙
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IEnumerable<int[]> GetMultiChoose(int n, int k)
    {
        return MathLibrary.GetMultiChooseIndexCollection(Enumerable.Range(0, n), k);
    }

    public static IEnumerable<int[]> GetMultiChooseIndexCollection(this IEnumerable<int> collection, int k)
    {
        if (k == 1)
        {
            foreach (var item in collection)
            {
                yield return new int[] { item };
            }
            yield break;
        }

        foreach (var item in collection)
        {
            var searchedArray = new int[] { item };
            var unsearchedArray = collection.SkipWhile(x => !x.Equals(item)).ToArray();
            foreach (var searchedItem in MathLibrary.GetMultiChooseIndexCollection(unsearchedArray, k - 1))
            {
                yield return searchedArray.Concat(searchedItem).ToArray();
            }
        }
    }

    public static IEnumerable<int[]> Distribution(int n, int k)
    {
        //仕切りの組合せ
        var partitions = MathLibrary.GetCombinationIndexCollection(n + k - 1, k - 1);

        foreach (var partition in partitions)
        {
            var newArray = (new int[] { -1 }).Concat(partition).Concat(new int[] { n + k - 1 }).ToArray();
            var array = new int[k];
            for (var i = 0; i < newArray.Length - 1; i++)
            {
                array[i] = newArray[i + 1] - newArray[i] - 1;
            }
            yield return array;
        }
    }

    #endregion

    #region "探索"

    public static int BinarySearch(this IList<int> sortedList, int key)
    {
        var left = 0;
        var right = sortedList.Count - 1;

        while (left <= right)
        {
            //区間の中央
            var middle = left + (left - right) / 2;
            if (sortedList[middle] == key)
            {
                return middle;
            }
            else if (sortedList[middle] < key)
            {
                right = middle;
            }
            else
            {
                left = middle;
            }
        }

        return -1;
    }

    public static int BinarySearch(int initOk, int initNg, Func<int, bool> isOk)
    {
        var ok = initOk;
        var ng = initNg;

        while (Math.Abs(ok - ng) > 1)
        {
            //区間の中央
            var middle = ok + (ng - ok) / 2;
            if (isOk(middle))
            {
                ok = middle;
            }
            else
            {
                ng = middle;
            }
        }
        return ok;
    }

    public static long BinarySearch(long initOk, long initNg, Func<long, bool> isOk)
    {
        var ok = initOk;
        var ng = initNg;

        while (Math.Abs(ok - ng) > 1)
        {
            //区間の中央
            var middle = ok + (ng - ok) / 2;
            if (isOk(middle))
            {
                ok = middle;
            }
            else
            {
                ng = middle;
            }
        }
        return ok;
    }

    public static int LowerBound(this IList<int> sortedList, int key)
    {
        var ng = -1;
        var ok = sortedList.Count;

        Func<int, bool> isOk = (target) =>
        {
            return sortedList[target] >= key;
        };

        return MathLibrary.BinarySearch(ok, ng, isOk);
    }

    public static long LowerBound(this IList<long> sortedList, long key)
    {
        var ng = -1;
        var ok = sortedList.Count;

        Func<int, bool> isOk = (target) =>
        {
            return sortedList[target] >= key;
        };

        return MathLibrary.BinarySearch(ok, ng, isOk);
    }

    public static int UpperBound(this IList<int> sortedList, int key)
    {
        var ng = -1;
        var ok = sortedList.Count;

        Func<int, bool> isOk = (target) =>
        {
            return sortedList[target] > key;
        };

        return MathLibrary.BinarySearch(ok, ng, isOk);
    }

    public static int UpperBound(this IList<long> sortedList, long key)
    {
        var ng = -1;
        var ok = sortedList.Count;

        Func<int, bool> isOk = (target) =>
        {
            return sortedList[target] > key;
        };

        return MathLibrary.BinarySearch(ok, ng, isOk);
    }

    #endregion

    #region "文字列"

    public static int Count(this string source, string searchStr)
    {
        return (source.Length - source.Replace(searchStr, "").Length) / searchStr.Length;
    }

    public static string SubStringEx(this string str, int startIndex, int length)
    {
        var minLength = Math.Min(str.Length - startIndex, length);
        var subStr = str.Substring(startIndex, minLength);
        return subStr;
    }

    #endregion

    #region "マトリックス"

    public static int[,] MatrixProduct(int[,] A, int[,] B)
    {
        var result = new int[3, 3];
        result[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0] + A[0, 2] * B[2, 0];
        result[0, 1] = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1] + A[0, 2] * B[2, 1];
        result[0, 2] = A[0, 0] * B[0, 2] + A[0, 1] * B[1, 2] + A[0, 2] * B[2, 2];
        result[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0] + A[1, 2] * B[2, 0];
        result[1, 1] = A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1] + A[1, 2] * B[2, 1];
        result[1, 2] = A[1, 0] * B[0, 2] + A[1, 1] * B[1, 2] + A[1, 2] * B[2, 2];
        result[2, 0] = A[2, 0] * B[0, 0] + A[2, 1] * B[1, 0] + A[2, 2] * B[2, 0];
        result[2, 1] = A[2, 0] * B[0, 1] + A[2, 1] * B[1, 1] + A[2, 2] * B[2, 1];
        result[2, 2] = A[2, 0] * B[0, 2] + A[2, 1] * B[1, 2] + A[2, 2] * B[2, 2];
        return result;
    }

    public static long[,] MatrixProduct(long[,] A, long[,] B)
    {
        var result = new long[3, 3];
        result[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0] + A[0, 2] * B[2, 0];
        result[0, 1] = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1] + A[0, 2] * B[2, 1];
        result[0, 2] = A[0, 0] * B[0, 2] + A[0, 1] * B[1, 2] + A[0, 2] * B[2, 2];
        result[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0] + A[1, 2] * B[2, 0];
        result[1, 1] = A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1] + A[1, 2] * B[2, 1];
        result[1, 2] = A[1, 0] * B[0, 2] + A[1, 1] * B[1, 2] + A[1, 2] * B[2, 2];
        result[2, 0] = A[2, 0] * B[0, 0] + A[2, 1] * B[1, 0] + A[2, 2] * B[2, 0];
        result[2, 1] = A[2, 0] * B[0, 1] + A[2, 1] * B[1, 1] + A[2, 2] * B[2, 1];
        result[2, 2] = A[2, 0] * B[0, 2] + A[2, 1] * B[1, 2] + A[2, 2] * B[2, 2];
        return result;
    }

    #endregion
}

public static class LinqEx
{
    #region "ソート"

    public static IEnumerable<string> Sort(this IEnumerable<string> collection)
    {
        return collection.ToArray().Sort();
    }

    public static string[] Sort(this string[] array)
    {
        Array.Sort(array, StringComparer.OrdinalIgnoreCase);
        return array;
    }

    public static IEnumerable<int> Sort(this IEnumerable<int> collection)
    {
        var array = collection.ToArray();
        return array.Sort();
    }

    public static int[] Sort(this int[] array)
    {
        Array.Sort(array);
        return array;
    }

    public static IEnumerable<long> Sort(this IEnumerable<long> collection)
    {
        var array = collection.ToArray();
        return array.Sort();
    }

    public static long[] Sort(this long[] array)
    {
        Array.Sort(array);
        return array;
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
    {
        return collection.OrderBy(item => Guid.NewGuid());
    }

    #endregion

    #region "生成"

    public static IEnumerable<long> Range(long start, long count)
    {
        var array = new long[count];
        for (var i = 0; i < count; i++)
        {
            array[i] = start + i;
        }
        return array;
    }

    public static IEnumerable<T> Repeat<T>(T element, long count)
    {
        var array = new T[count];
        for (var i = 0; i < count; i++)
        {
            array[i] = element;
        }
        return array;
    }

    #endregion

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> collection, long count)
    {
        var array = collection.ToArray();
        if (array.LongLength <= count)
        {
            return new T[0];
        }

        var list = new List<T>();
        for (long i = count; i < array.LongLength; i++)
        {
            list.Add(array[i]);
        }
        return list;
    }

    /// <summary>
    /// 階差数列
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IEnumerable<long> FloorDiff(this IEnumerable<long> collection)
    {
        var diff = collection.Skip(1);
        var result = diff.Zip(collection, (e1, e2) => e1 - e2);
        return result;
    }

    #region "コレクション"

    public static IList<T> CreateList<T>(T item)
    {
        return new List<T>();
    }

    #endregion
}

#region

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

public struct GenericMatrix<T>
{
    private T[] array;

    public GenericMatrix(long row, long col)
    {
        this.RowCount = row;
        this.ColumnCount = col;
        this.array = new T[row * col];
    }

    #region 

    #endregion

    public long RowCount { get; }

    public long ColumnCount { get; }

    public T this[long row, long column]
    {
        get
        {
            var index = this.ColumnCount * row + column;
            return this.array[index];
        }
    }

    public void Init(long rowIndex, T[] rowItem)
    {
        if (rowItem.Length != this.ColumnCount)
        {
            throw new InvalidOperationException();
        }

        for (var i = 0; i < rowItem.Length; i++)
        {
            var index = rowItem.Length * rowIndex + i;
            this.array[index] = rowItem[i];
        }
    }

    public T[] GetRow(long rowIndex)
    {
        var vector = new T[this.ColumnCount];
        for (var i = 0; i < vector.Length; i++)
        {
            vector[i] = this[rowIndex, i];
        }
        return vector;
    }

    public T[] GetColumn(long colIndex)
    {
        var vector = new T[this.RowCount];
        for (var i = 0; i < vector.Length; i++)
        {
            var rowIndex = this.ColumnCount * i + colIndex;
            vector[i] = this[rowIndex, colIndex];
        }
        return vector;
    }
}

public struct Matrix
{
    private GenericMatrix<long> matrix;

    public Matrix(long row, long col)
    {
        this.matrix = new GenericMatrix<long>(row, col);
    }

    #region 

    public long RowCount
    {
        get { return this.matrix.RowCount; }
    }

    public long ColumnCount
    {
        get { return this.matrix.ColumnCount; }
    }

    public static Matrix operator +(Matrix a)
    {
        return a;
    }

    public static Matrix operator -(Matrix a)
    {
        return -1 * a;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.RowCount != b.RowCount || a.ColumnCount != b.ColumnCount)
        {
            throw new InvalidOperationException();
        }

        var result = new Matrix(a.RowCount, a.ColumnCount);

        for (var rowIndex = 0; rowIndex < a.RowCount; rowIndex++)
        {
            var rowItem = a.GetRow(rowIndex).Zip(b.GetRow(rowIndex), (elementA, elementB) => elementA + elementB)
                                            .ToArray();
            result.Init(rowIndex, rowItem);
        }
        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        return a + (-b);
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.ColumnCount != b.RowCount)
        {
            throw new InvalidOperationException();
        }

        var result = new Matrix(a.RowCount, b.ColumnCount);
        for (var rowIndex = 0; rowIndex < a.RowCount; rowIndex++)
        {
            var rowItem = new long[result.ColumnCount];
            var vectorA = a.GetRow(rowIndex);

            for (var columnIndex = 0; columnIndex < b.ColumnCount; columnIndex++)
            {
                var vectorB = b.GetColumn(columnIndex);

                var index = a.ColumnCount * rowIndex + columnIndex;
                var value = vectorA.Zip(vectorB, (elementA, elementB) => elementA * elementB)
                                   .Sum();
                rowItem[index] = value;
            }
            result.Init(rowIndex, rowItem);
        }

        return result;
    }

    public static Matrix operator *(long c, Matrix a)
    {
        var result = new Matrix(a.RowCount, a.ColumnCount);
        for (var rowIndex = 0; rowIndex < a.RowCount; rowIndex++)
        {
            var rowItem = a.GetRow(rowIndex);
            result.Init(rowIndex, rowItem.Select(element => element * c).ToArray());
        }
        return result;
    }

    public static Matrix operator *(Matrix a, long c)
    {
        return c * a;
    }

    #endregion

    public long this[long row, long column]
    {
        get { return this.matrix[row, column]; }
    }

    public void Init(long rowIndex, long[] rowItem)
    {
        this.matrix.Init(rowIndex, rowItem);
    }

    /// <summary>
    /// 行列式
    /// </summary>
    /// <returns></returns>
    public long Determinant()
    {
        return 0;
    }

    public long[] GetRow(long rowIndex)
    {
        return this.matrix.GetRow(rowIndex);
    }

    public long[] GetColumn(long colIndex)
    {
        return this.matrix.GetColumn(colIndex);
    }
}

public struct Cell : IEquatable<Cell>
{
    public Cell(long row, long column)
    {
        this.Row = row;
        this.Column = column;
    }

    public long Row { get; }

    public long Column { get; }

    #region 

    public static bool operator ==(Cell cell1, Cell cell12)
    {
        return cell1.Equals(cell12);
    }

    public static bool operator !=(Cell cell1, Cell cell12)
    {
        return !(cell1 == cell12);
    }

    #endregion

    public bool Equals(Cell other)
    {
        return this.Row == other.Row && this.Column == other.Column;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Cell))
        {
            return false;
        }

        return this.Equals((Cell)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Row, this.Column);
    }

    public override string ToString()
    {
        return $"({this.Row}, {this.Column})";
    }
}

public abstract class ProblemBase
{
    public virtual void SolveA()
    {
    }

    public virtual void SolveB()
    {
    }

    public virtual void SolveC()
    {
    }

    public virtual void SolveD()
    {
    }

    public virtual void SolveE()
    {
    }

    public virtual void SolveF()
    {
    }
}

#endregion

#endregion