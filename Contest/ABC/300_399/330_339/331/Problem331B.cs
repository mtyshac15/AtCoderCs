using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC331;

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

    /// <summary>
    /// Buy One Carton of Milk
    /// </summary>
    public void Solve()
    {
        var NSML = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NSML[0];
        var S = NSML[1];
        var M = NSML[2];
        var L = NSML[3];

        var ans = int.MaxValue;

        for (int s = 0; s <= N; s++)
        {
            for (int m = 0; m <= N; m++)
            {
                for (int l = 0; l <= N; l++)
                {
                    var count = 6 * s + 8 * m + 12 * l;
                    if (count >= N)
                    {
                        var total = S * s + M * m + L * l;
                        ans = Math.Min(total, ans);
                    }
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
