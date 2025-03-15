using Xunit;
using Xunit.Abstractions;

namespace Training.Tests.Library;

[Trait("Category", "learning")]
public class PrimeTest
{
    private ITestOutputHelper _output;

    public PrimeTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact(Skip = "愚直")]
    [Trait("Memo", "10^7 で 15s")]
    public void N以下の素数表を作成_素数判定()
    {
        _output.WriteLine("Arrange");
        var N = 10_000_000;

        _output.WriteLine("Act");
        var sw = System.Diagnostics.Stopwatch.StartNew();

        var primes = new List<int>();
        for (int i = 2; i <= N; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }

        sw.Stop();
        var second = (int)(sw.Elapsed.TotalMilliseconds);

        _output.WriteLine("Assert");
        _output.WriteLine($"{primes.Count} {second} ms");
    }

    [Fact]
    [Trait("Memo", "10^7 で 400ms")]
    [Trait("Memo", "10^8 で 2000ms")]
    public void N以下の素数表を作成_エラトステネスの篩()
    {
        _output.WriteLine("Arrange");
        var N = 10_000_000;

        _output.WriteLine("Act");
        var sw = System.Diagnostics.Stopwatch.StartNew();
        var primes = Primes(N);

        sw.Stop();
        var second = (int)(sw.Elapsed.TotalMilliseconds);

        _output.WriteLine("Assert");
        _output.WriteLine($"{primes.Length} {second} ms");
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
