using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC090;

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
    /// Diagonal String
    /// </summary>
    public void Solve()
    {
        var c = new string[3];
        for (int i = 0; i < 3; i++)
        {
            c[i] = _reader.ReadLine().Trim();
        }

        var ans = $"{c[0][0]}{c[1][1]}{c[2][2]}";
        _writer.WriteLine(ans);
    }
}
