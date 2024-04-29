using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC139;

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
    /// Lower
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var H = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var sub = H.Zip(H.Skip(1), (h1, h2) => h1 - h2);

        var ans = 0;
        var count = 0;

        //0以上の数がいくつ連続で続くかを探索
        foreach (var e in sub)
        {
            if (e >= 0)
            {
                count++;
            }
            else
            {
                ans = Math.Max(ans, count);
                count = 0;
            }
        }

        ans = Math.Max(ans, count);
        _writer.WriteLine(ans);
    }
}
