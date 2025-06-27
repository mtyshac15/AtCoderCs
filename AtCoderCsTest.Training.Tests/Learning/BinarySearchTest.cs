using Xunit.Abstractions;

namespace AtCoderCsTest.Training.Tests.Learning;

[Trait("Category", "Learning")]
public class BinarySearchTest
{
  private ITestOutputHelper _output;

  public BinarySearchTest(ITestOutputHelper output)
  {
    _output = output;
  }

  [Theory(DisplayName = "要素あり 重複なし")]
  [InlineData(1, 0)]
  [InlineData(10, 9)]
  public void 要素の重複がない場合一致した要素のインデックスを返す(int sutValue, int expected)
  {
    _output.WriteLine("Arrange");
    var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    _output.WriteLine("Act");
    var index = Array.BinarySearch(array, sutValue);

    _output.WriteLine("Assert");

    var ans = index;
    _output.WriteLine($"expected: {expected}");
    _output.WriteLine($"actual: {ans}");
    Assert.Equal(expected, ans);
  }

  [Theory(DisplayName = "要素あり 重複あり")]
  [InlineData(1, 0)]
  [InlineData(10, 11)]
  public void 要素の重複がある場合最初に一致した要素のインデックスを返す(int sutValue, int expected)
  {
    _output.WriteLine("Arrange");
    var array = new int[] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 9, 10, 10 };

    _output.WriteLine("Act");
    var index = Array.BinarySearch(array, sutValue);

    _output.WriteLine("Assert");

    var ans = index;
    _output.WriteLine($"expected: {expected}");
    _output.WriteLine($"actual: {ans}");
    Assert.Equal(expected, ans);
  }

  [Theory(DisplayName = "Lower bound")]
  [InlineData(0, 0)]
  [InlineData(1, 0)]
  [InlineData(2, 2)]
  [InlineData(9, 3)]
  [InlineData(10, 3)]
  [InlineData(11, 5)]
  public void その値以上の要素のうち最初のインデックスを返す(int sutValue, int expected)
  {
    _output.WriteLine("Arrange");
    var array = new int[] { 1, 1, 5, 10, 10 };

    _output.WriteLine("Act");
    var index = LowerBound(array, sutValue);

    _output.WriteLine("Assert");

    var ans = index;
    _output.WriteLine($"expected: {expected}");
    _output.WriteLine($"actual: {ans}");
    Assert.Equal(expected, ans);
  }

  [Theory(DisplayName = "Upper bound")]
  [InlineData(0, 0)]
  [InlineData(1, 2)]
  [InlineData(2, 2)]
  [InlineData(9, 3)]
  [InlineData(10, 5)]
  [InlineData(11, 5)]
  public void その値より大きい要素のうち最初のインデックスを返す(int sutValue, int expected)
  {
    _output.WriteLine("Arrange");
    var array = new int[] { 1, 1, 5, 10, 10 };

    _output.WriteLine("Act");
    var index = UpperBound(array, sutValue);

    _output.WriteLine("Assert");

    var ans = index;
    _output.WriteLine($"expected: {expected}");
    _output.WriteLine($"actual: {ans}");
    Assert.Equal(expected, ans);
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
      // 要素がないとき、valueより大きい最初の要素のインデックスのビットごとの補数を返すため補数を戻す
      return ~index;
    }

    return index;
  }

  public static int UpperBound(int[] array, int key)
  {
    var index = Array.BinarySearch(array, key);
    if (index < 0)
    {
      // 要素がないとき、valueより大きい最初の要素のインデックスのビットごとの補数を返すため補数を戻す
      return ~index;
    }

    // 見つかった場合、同じ値が連続している可能性があるので、その値より大きい最初のインデックスを返す
    while (index < array.Length && array[index] == key)
    {
      index++;
    }

    return index;
  }
}
