using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC121;

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
    /// White Cells
    /// </summary>
    public void Solve()
    {
        var HW = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = HW[0];
        var W = HW[1];

        var hw = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];

        var ans = (H - h) * (W - w);
        _writer.WriteLine(ans);
    }
}
