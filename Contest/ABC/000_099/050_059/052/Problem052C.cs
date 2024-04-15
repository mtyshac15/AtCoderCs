using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC052;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Factors of Factorial
    /// </summary>
    public void Solve()
    {
        var mod = 1000000007;
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var primeArray = new int[N + 1];

        for (int i = 2; i <= N; i++)
        {
            //約数
            for (int j = 2; j <= i; j++)
            {
                var isPrime = true;

                //素因数分解
                for (int k = 2; k * k <= j; k++)
                {
                    if (j % k == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime
                    && i % j == 0)
                {
                    //jが素数のとき、割り切れなくなるまで割り算を繰り返す
                    var tempI = i;
                    while (true)
                    {
                        if (tempI % j != 0)
                        {
                            break;
                        }

                        primeArray[j]++;
                        tempI /= j;
                    }
                }
            }
        }

        var ans = 1L;
        for (int i = 0; i < primeArray.Length; i++)
        {
            var factor = primeArray[i];
            if (factor > 0)
            {
                ans *= factor + 1;
                ans %= mod;
            }
        }

        _writer.WriteLine(ans);
    }
}
