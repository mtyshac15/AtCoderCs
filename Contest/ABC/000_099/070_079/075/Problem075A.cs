using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC075;

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
    /// One out of Three
    /// </summary>
    public void Solve()
    {
        var ABC = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = ABC[0];
        var B = ABC[1];
        var C = ABC[2];

        var ans = 0;
        if (A == B)
        {
            ans = C;
        }
        else if (A == C)
        {
            ans = B;
        }
        else
        {
            ans = A;
        }

        _writer.WriteLine(ans);
    }
}
