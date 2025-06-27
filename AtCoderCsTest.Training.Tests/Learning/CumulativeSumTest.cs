using AtCoderCs.Common.Library;
using Xunit.Abstractions;

namespace AtCoderCsTest.Training.Tests.Learning;

[Trait("Category", "Learning")]
public class CumulativeSumTest
{
  private ITestOutputHelper _output;

  public CumulativeSumTest(ITestOutputHelper output)
  {
    _output = output;
  }

  [Theory]
  [InlineData(0, 0, 0)]
  [InlineData(0, 1, 2)]
  [InlineData(0, 2, 7)]
  [InlineData(1, 4, 11)]
  [InlineData(3, 5, 13)]
  public void Left以上Right未満のインデックスの範囲にある要素の和(int left, int right, int expected)
  {
    _output.WriteLine("Arrange");
    var array = new int[] { 2, 5, -4, 10, 3 };

    _output.WriteLine("Act");
    var sum = MathLibrary.CumulativeSum(array);

    _output.WriteLine("Assert");
    var ans = sum[right] - sum[left];
    Assert.Equal(expected, ans);
  }
}
