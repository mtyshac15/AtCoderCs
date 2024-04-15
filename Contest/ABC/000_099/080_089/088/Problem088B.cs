using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC088;

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
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var a = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Array.Sort(a);
        var sortedA = a.Reverse();

        var ans = 0;
        var sign = 1;
        foreach (var card in sortedA)
        {
            ans += card * sign;
            sign *= -1;
        }

        _writer.WriteLine(ans);
    }
}
