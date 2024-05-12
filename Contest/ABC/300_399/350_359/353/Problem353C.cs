using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC353;

public class ProblemC
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var cons = 100000000;

        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();

        Array.Sort(A);

        //累積和
        var s = new long[N + 1];
        for (var i = 0; i < N; i++)
        {
            s[i + 1] = s[i] + A[i];
        }

        //x+y >= 10^18 を満たすペアの個数を求める
        var count = 0L;
        for (int i = 0; i < N - 1; i++)
        {
            var x = A[i];

            // x+y >=10^18を満たす最小のyを求める
            var ng = i;
            var ok = N;
            while (Math.Abs(ok - ng) > 1)
            {
                var middle = ng + (ok - ng) / 2;
                if (x + A[middle] >= cons)
                {
                    ok = middle;
                }
                else
                {
                    ng = middle;
                }
            }

            count += N - ok;
        }

        var ans = s[N] * (N - 1) - cons * count;
        _writer.WriteLine(ans);
    }
}
