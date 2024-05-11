using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC098;

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
        var S = _reader.ReadLine().Trim();

        var ans = 0;
        for (int i = 0; i < S.Length; i++)
        {
            var X = S.Substring(0, i).Distinct().ToArray();
            var Y = S.Substring(i, S.Length - i).ToHashSet();

            var count = 0;
            for (int j = 0; j < X.Length; j++)
            {
                if (Y.Contains(X[j]))
                {
                    count++;
                }
            }

            ans = Math.Max(count, ans);
        }

        _writer.WriteLine(ans);
    }
}
