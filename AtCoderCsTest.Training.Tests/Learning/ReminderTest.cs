using AtCoderCs.Common.Library;
using Xunit.Abstractions;

namespace AtCoderCsTest.Training.Tests.Learning;

[Trait("Category", "Learning")]
public class ReminderTest
{
  private ITestOutputHelper _output;

  public ReminderTest(ITestOutputHelper output)
  {
    _output = output;
  }

  [Theory]
  [InlineData(33, 88, 11)]
  public void 最大公約数(int a, int b, int expected)
  {
    _output.WriteLine("Arrange");
    _output.WriteLine("Act");

    var actual = Gcd(a, b);

    _output.WriteLine("Assert");
    Assert.Equal(expected, actual);
  }

  public int Gcd(int a, int b)
  {
    if (b == 0)
    {
      return a;
    }

    return Gcd(b, a % b);
  }
}
