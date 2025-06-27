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
    var actual = IsPrime(sutValue);

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
    var primes = Primes(N);

    _output.WriteLine("Assert");
  }

  /// <summary>
  /// 素数判定
  /// </summary>
  /// <param name="n"></param>
  /// <returns></returns>
  public static bool IsPrime(long n)
  {
    if (n <= 1
        || n > 2 && n % 2 == 0)
    {
      return false;
    }

    for (long i = 2; i * i <= n; i++)
    {
      if (n % i == 0)
      {
        return false;
      }
    }
    return true;
  }

  public static int[] Primes(int n)
  {
    var primes = new bool[n + 1];
    for (int i = 0; i < n; i++)
    {
      primes[i] = true;
    }

    primes[0] = false;
    primes[1] = false;

    for (int i = 2; i * i <= n; i++)
    {
      if (IsPrime(i))
      {
        for (int j = i * i; j <= n; j += i)
        {
          primes[j] = false;
        }
      }
    }

    // リストに変換
    return primes.Select((e, i) => e ? i : -1).Where(e => e > 0).ToArray();
  }
}
