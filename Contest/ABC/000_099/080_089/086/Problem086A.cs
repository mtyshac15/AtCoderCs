using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC086;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Product
    /// </summary>
    public void Solve()
    {
        var ab = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];

        var ans = string.Empty;
        if (a * b % 2 == 1)
        {
            ans = $"Odd";
        }
        else
        {
            ans = $"Even";
        }

        _writer.WriteLine(ans);
    }
}
