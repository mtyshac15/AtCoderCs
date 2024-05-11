using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC106;

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
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0;
        for (int i = 1; i <= N; i += 2)
        {
            var divisorCount = 0;

            //–ñ”‚ÌŒÂ”
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    divisorCount++;
                }
            }

            if (divisorCount == 8)
            {
                ans++;
            }
        }

        _writer.WriteLine(ans);
    }
}
