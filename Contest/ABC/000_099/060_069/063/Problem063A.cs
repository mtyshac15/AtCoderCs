using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC063;

public class ProblemA
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Restricted
    /// </summary>
    public void Solve()
    {
        var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = AB[0];
        var B = AB[1];

        var ans = A + B;
        if (ans >= 10)
        {
            _writer.WriteLine($"error");
        }
        else
        {
            _writer.WriteLine(ans);
        }
    }
}
