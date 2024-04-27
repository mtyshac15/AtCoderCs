using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace AtCoderCs.Contest.ABC056;

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
    /// Go Home
    /// </summary>
    public void Solve()
    {
        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0;
        var current = 0L;
        for (var t = 1; t < X; t++)
        {
            current += t;
            if (current >= X)
            {
                ans = t;
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
