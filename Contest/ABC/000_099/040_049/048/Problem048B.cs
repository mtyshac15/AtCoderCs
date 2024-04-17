using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC048;

public class ProblemB
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var abx = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        var a = abx[0];
        var b = abx[1];
        var x = abx[2];

        var ans = 0L;
        if (b == 0)
        {
            ans = 1;
        }
        else
        {
            if (a == 0)
            {
                // 0以上、b以下の数のうち、xで割り切れる数の個数
                ans = b / x + 1;
            }
            else
            {
                // 1以上、a未満の数のうち、xで割り切れる数の個数
                var countA = (a - 1) / x;

                //1以上、b以下の数のうち、xで割り切れる数の個数
                var countB = b / x;

                ans = countB - countA;
            }
        }

        _writer.WriteLine(ans);
    }
}
