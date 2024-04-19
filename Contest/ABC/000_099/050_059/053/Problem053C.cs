using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC053;

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
    /// X: Yet Another Die Game
    /// </summary>
    public void Solve()
    {
        var x = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var quotient = x / 11;
        var remainder = x % 11;

        var ans = quotient * 2;
        if (remainder >= 1 && remainder <= 6)
        {
            ans += 1;
        }
        else if (remainder >= 7)
        {
            ans += 2;
        }

        _writer.WriteLine(ans);
    }
}
