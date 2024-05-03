using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC078;

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
    /// HEX
    /// </summary>
    public void Solve()
    {
        var XY = _reader.ReadLine().Trim().Split();
        var X = XY[0][0];
        var Y = XY[1][0];

        var ans = string.Empty;
        if (X == Y)
        {
            ans = "=";
        }
        else if (X - 'A' < Y - 'A')
        {
            ans = "<";
        }
        else
        {
            ans = ">";
        }

        _writer.WriteLine(ans);
    }
}
