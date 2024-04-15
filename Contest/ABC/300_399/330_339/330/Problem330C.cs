using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC330;

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
    /// Minimize Abs 2
    /// </summary>
    public void Solve()
    {
        var D = _reader.ReadLine().Trim().Split().Select(long.Parse).ToList()[0];
        var ans = this.Calc(D);
        _writer.WriteLine(ans);
    }

    public long Calc(long D)
    {
        // n*n<=Dを満たす最大のn
        var rootD = 0L;
        while (rootD * rootD <= D)
        {
            rootD++;
        }
        rootD--;

        var ans = long.MaxValue;
        var y = rootD;

        for (long x = 0L; x <= rootD + 1; x++)
        {
            if (x * x + y * y > D)
            {
                //円の外部
                y--;
            }

            for (int i = 0; i < 2; i++)
            {
                //円の内部と外部の点に対してそれぞれ計算
                var value = Math.Abs(x * x + (y + i) * (y + i) - D);
                ans = Math.Min(value, ans);
            }
        }

        return ans;
    }
}
