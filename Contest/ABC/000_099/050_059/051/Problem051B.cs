using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC051;

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
    /// Sum of Three Integers
    /// </summary>
    public void Solve()
    {
        var KS = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var K = KS[0];
        var S = KS[1];

        var ans = 0;

        for (int X = 0; X <= K; X++)
        {
            for (int Y = 0; Y <= K; Y++)
            {
                var Z = S - X - Y;
                if (Z >= 0 && Z <= K)
                {
                    ans++;
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
