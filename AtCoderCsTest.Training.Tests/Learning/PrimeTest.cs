using AtCoderCs.Common.Library;
using Xunit.Abstractions;

namespace AtCoderCsTest.Training.Tests.Learning;

[Trait("Category", "Learning")]
public class PrimeTest
{
  private ITestOutputHelper _output;

  public PrimeTest(ITestOutputHelper output)
  {
    _output = output;
  }

  [Theory]
  [InlineData(17, true)]
  [InlineData(31, true)]
  [InlineData(35, false)]
  [InlineData(49, false)]
  public void 素数判定(int sutValue, bool expected)
  {
    _output.WriteLine("Arrange");
    _output.WriteLine("Act");
    var actual = MathLibrary.IsPrime(sutValue);

    _output.WriteLine("Assert");
    Assert.Equal(expected, actual);
  }

  [Fact]
  [Trait("Memo", "10^7 で 400ms")]
  [Trait("Memo", "10^8 で 2000ms")]
  public void N以下の素数表を作成_エラトステネスの篩()
  {
    _output.WriteLine("Arrange");
    var N = 10_000_000;

    _output.WriteLine("Act");
    var primes = MathLibrary.Primes(N);

    _output.WriteLine("Assert");
  }
}
