using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC073;

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
    /// Theater
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var l = new int[N];
        var r = new int[N];
        for (int i = 0; i < N; i++)
        {
            var lr = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            l[i] = lr[0];
            r[i] = lr[1];
        }

        var ans = 0;
        for (int i = 0; i < N; i++)
        {
            ans += r[i] - l[i] + 1;
        }

        _writer.WriteLine(ans);
    }
}
