using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC114;

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
    /// 754
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var ans = int.MaxValue;
        for (int i = 0; i < S.Length - 2; i++)
        {
            var X = int.Parse(S.Substring(i, 3));
            ans = Math.Min(ans, Math.Abs(X - 753));
        }

        _writer.WriteLine(ans);
    }
}
