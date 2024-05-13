using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC099;

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

    public void Solve()
    {
        var ab = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];

        //ìåë§ÇÃìÉÇÃçÇÇ≥ÇÕÅA1+2+...+(b-a)
        var ans = (1 + b - a) * (b - a) / 2 - b;
        _writer.WriteLine(ans);
    }
}
