using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC122;

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
    /// Double Helix
    /// </summary>
    public void Solve()
    {
        var b = _reader.ReadLine().Trim();

        var ans = string.Empty;

        switch (b)
        {
            case "A":
                ans = "T";
                break;

            case "C":
                ans = "G";
                break;

            case "G":
                ans = "C";
                break;

            case "T":
                ans = "A";
                break;
        }

        _writer.WriteLine(ans);
    }
}
