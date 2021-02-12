using System;
using System.Collections.Generic;
using System.Linq;

public static class MathLibrary
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
        for (var i = 1L; i * i <= n; i++)
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
        for (var i = 2; i * i <= n; i++)
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
    public static void PrimeFactorization()
    {
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

    /// <summary>
    /// 桁数
    /// </summary>
    /// <param name="num"></param>
    /// <param name="basis"></param>
    /// <returns></returns>
    public static int Digits(this long num, int basis = 10)
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

    public static int Digits(long num, int n, int basis = 10)
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
    public static string ToOct(this int num)
    {
        return MathLibrary.ToOct((long)num);
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
    public static string ToHex(this int num)
    {
        return num.ToString("x");
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
    /// 指定したビットが1かどうか
    /// </summary>
    /// <param name="source"></param>
    /// <param name="bit"></param>
    /// <returns></returns>
    public static bool TestBit(int source, int bit)
    {
        return (source & (1 << bit)) > 0;
    }

    public static int bitCount(int i)
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
    /// 順列を列挙
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IEnumerable<int[]> GetPermutationIndexList(int n)
    {
        return MathLibrary.GetPermutationIndex(Enumerable.Range(0, n));
    }

    public static IEnumerable<int[]> GetPermutationIndex(IEnumerable<int> collection)
    {
        var indexList = new List<int[]>();

        if (collection.Count() == 1)
        {
            yield return new int[] { collection.First() };
            yield break;
        }

        foreach (var item in collection)
        {
            var searchedArray = new int[] { item };
            var unsearchedList = collection.Except(searchedArray).ToArray();

            var list = MathLibrary.GetPermutationIndex(unsearchedList);
            foreach (var searchedItem in list)
            {
                yield return searchedArray.Concat(searchedItem).ToArray();
            }
        }
    }

    /// <summary>
    /// 順列を列挙
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IEnumerable<T[]> GetPermutation<T>(IEnumerable<T> collection)
    {
        if (collection.Count() == 1)
        {
            yield return new T[] { collection.First() };
            yield break;
        }

        foreach (var item in collection)
        {
            var searchedList = new T[] { item };
            var unsearchedList = collection.Except(searchedList);
            foreach (var searchedItem in MathLibrary.GetPermutation(unsearchedList))
            {
                yield return searchedList.Concat(searchedItem).ToArray();
            }
        }
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

    #endregion

    #region "文字列"

    public static string SubStringEx(this string str, int startIndex, int length)
    {
        var minLength = Math.Min(str.Length - startIndex, length);
        var subStr = str.Substring(startIndex, minLength);
        return subStr;
    }

    #endregion

    #region "コレクション"

    public static IList<T> CreateList<T>(T item)
    {
        return new List<T>();
    }

    /// <summary>
    /// 累積和
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static IEnumerable<int> CumulativeSum(this IEnumerable<int> sequence)
    {
        var sum = 0;
        foreach (var item in sequence)
        {
            sum += item;
            yield return sum;
        }
    }

    /// <summary>
    /// 累積和
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static IEnumerable<ModInt> CumulativeSum(this IEnumerable<ModInt> sequence)
    {
        ModInt sum = 0;
        foreach (var item in sequence)
        {
            sum += item;
            yield return sum;
        }
    }

    /// <summary>
    /// 累積和
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static IEnumerable<long> CumulativeSum(this IEnumerable<long> sequence)
    {
        var sum = 0L;
        foreach (var item in sequence)
        {
            sum += item;
            yield return sum;
        }
    }

    public static int InnerProduct(IList<int> a, IList<int> b)
    {
        var sum = 0;
        for (var i = 0; i < a.Count; i++)
        {
            sum += a[i] * b[i];
        }
        return sum;
    }

    public static int InnerSum(IList<int> a, IList<int> b)
    {
        var sum = 0;
        for (var i = 0; i < a.Count; i++)
        {
            sum += a[i] + b[i];
        }
        return sum;
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