using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderCs.Common.Library;

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

    public static IEnumerable<long> LongRange(long start, long count)
    {
        var array = new long[count];
        for (var i = 0; i < count; i++)
        {
            array[i] = start + i;
        }
        return array;
    }
    #endregion

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