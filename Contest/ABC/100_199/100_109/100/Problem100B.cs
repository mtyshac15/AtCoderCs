using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC100;

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
        var DN = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var D = DN[0];
        var N = DN[1];

        var num = 1;
        for (int i = 0; i < D; i++)
        {
            num *= 100;
        }

        var order = N < 100 ? N : N + 1;
        var ans = order * num;
        _writer.WriteLine(ans);
    }
}
