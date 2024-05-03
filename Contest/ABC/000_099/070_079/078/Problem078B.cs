using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC078;

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
    /// ISU
    /// </summary>
    public void Solve()
    {
        var XYZ = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var X = XYZ[0];
        var Y = XYZ[1];
        var Z = XYZ[2];

        // nY + (n+1)Z <= X
        var ans = (X - Z) / (Y + Z);
        _writer.WriteLine(ans);
    }
}
