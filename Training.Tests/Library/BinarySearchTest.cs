using System.ComponentModel;
using System.Numerics;
using Xunit;
using Xunit.Abstractions;

namespace Training.Tests.Library;

[Trait("Category", "learning")]
public class BinarySearchTest
{
    private ITestOutputHelper _output;
    private Random _random;

    public BinarySearchTest(ITestOutputHelper output)
    {
        _output = output;
        _random = new Random();
    }

    private long[] CreateArray(int n)
    {
        return Enumerable.Repeat(0, n).Select(x => _random.NextInt64(long.MinValue + 1, long.MaxValue)).ToArray();
    }

    [Fact(DisplayName = "binary_search_自作")]
    public void 二分探索_一致_自作()
    {
        _output.WriteLine("Arrange");
        var N = 10_000_000;

        var array = CreateArray(N);

        var expected = _random.Next(array.Length);

        _output.WriteLine("Act");
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Array.Sort(array);

        var isOk = (int key) =>
        {
            return array[key] <= array[expected];
        };

        var index = BinarySearch(array, isOk);

        sw.Stop();
        var second = (int)(sw.Elapsed.TotalMilliseconds);

        _output.WriteLine("Assert");
        _output.WriteLine($" {second} ms");

        var ans = index;
        _output.WriteLine($"expected: {expected}");
        _output.WriteLine($"actual: {ans}");
        Assert.Equal(expected, ans);
    }

    [Fact(DisplayName = "binary_search_array")]
    public void 二分探索_一致_標準関数()
    {
        _output.WriteLine("Arrange");
        var N = 10_000_000;

        var array = CreateArray(N);

        var expected = _random.Next(array.Length);

        _output.WriteLine("Act");
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Array.Sort(array);

        var index = Array.BinarySearch(array, expected);

        sw.Stop();
        var second = (int)(sw.Elapsed.TotalMilliseconds);
        _output.WriteLine($" {second} ms");

        _output.WriteLine("Assert");

        var ans = index;
        _output.WriteLine($"expected: {expected}");
        _output.WriteLine($"actual: {ans}");
        //Assert.Equal(expected, ans);
    }

    [Theory(DisplayName = "lower_bound_自作")]
    [InlineData(0)]
    public void 二分探索_検索キー以上の最小値(int expectedValue)
    {
        _output.WriteLine("Arrange");
        var N = 1_000_000;
        var array = Enumerable.Repeat(0, N).Select(x => _random.Next(int.MinValue + 1, int.MaxValue - 1)).ToArray();

        _output.WriteLine("Act");
        Array.Sort(array);

        var isOk = (int key) =>
        {
            return array[key] <= expectedValue;
        };

        var index = BinarySearch(array, isOk);

        _output.WriteLine("Assert");

        var ans = index;
        _output.WriteLine($"actual index: {ans}");
        _output.WriteLine($"index: {array[index]}");
        _output.WriteLine($"index + 1: {array[index + 1]}");

        Assert.True(array[index] <= 0);
        Assert.True(array[index + 1] > 0);
    }

    [Fact(DisplayName = "lower_bound_max")]
    public void 二分探索_検索キー以上の最小値_最大値より大きい場合()
    {
        _output.WriteLine("Arrange");
        var N = 1_000_000;
        var array = Enumerable.Repeat(0, N).Select(x => _random.Next(int.MinValue + 1, int.MaxValue - 1)).ToArray();

        _output.WriteLine("Act");
        Array.Sort(array);

        var index = LowerBound(array, int.MaxValue);

        _output.WriteLine("Assert");
        var ans = index;

        _output.WriteLine($"actual: {ans}");
        Assert.Equal(array.Length, ans);
        Assert.True(array[index - 1] < int.MaxValue);
    }

    [Fact(DisplayName = "lower_bound_min")]
    public void 二分探索_検索キー以上の最小値_最小値より小さい場合()
    {
        _output.WriteLine("Arrange");
        var N = 1_000_000;
        var array = Enumerable.Repeat(0, N).Select(x => _random.Next(int.MinValue + 1, int.MaxValue - 1)).ToArray();

        _output.WriteLine("Act");
        Array.Sort(array);

        var index = LowerBound(array, int.MinValue);

        _output.WriteLine("Assert");
        var ans = index;

        _output.WriteLine($"actual: {ans}");
        Assert.Equal(0, ans);
        Assert.True(array[index] > int.MinValue);
    }
    public static int BinarySearch<T>(IReadOnlyList<T> list, Func<int, bool> isOk)
    {
        var ok = -1;
        var ng = list.Count;
        while (Math.Abs(ok - ng) > 1)
        {
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

    public static int LowerBound(int[] array, int key)
    {
        var index = Array.BinarySearch(array, key);
        if (index < 0)
        {
            index = ~index;
        }
        return index;
    }
}
