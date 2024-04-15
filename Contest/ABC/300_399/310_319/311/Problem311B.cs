using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC311;

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
    /// Vacation Together
    /// </summary>
    public void Solve()
    {
        var ND = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = ND[0];
        var D = ND[1];

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = _reader.ReadLine().Trim();
        }

        var ans = 0;
        var count = 0;
        for (int i = 0; i < D; i++)
        {
            var isFree = true;
            for (int j = 0; j < N; j++)
            {
                if (S[j][i] != 'o')
                {
                    isFree = false;
                    count = 0;
                    break;
                }
            }

            if (isFree)
            {
                count++;
                ans = Math.Max(count, ans);
            }
        }

        _writer.WriteLine(ans);
    }
}
