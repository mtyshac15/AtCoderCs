using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC050;

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
    /// Addition and Subtraction Easy
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split();
        var A = int.Parse(input[0]);
        var op = input[1];
        var B = int.Parse(input[2]);

        var ans = 0;
        if (op == "+")
        {
            ans = A + B;
        }
        else if (op == "-")
        {
            ans = A - B;
        }

        _writer.WriteLine(ans);
    }
}
