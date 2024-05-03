using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC079;

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
    /// Lucas Number
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0L;
        if (N == 1)
        {
            ans = 1;
        }
        else
        {
            var Li = 2L;
            var Li1 = 1L;

            for (int i = 2; i <= N; i++)
            {
                ans = Li1 + Li;
                Li = Li1;
                Li1 = ans;
            }
        }

        _writer.WriteLine(ans);
    }
}
