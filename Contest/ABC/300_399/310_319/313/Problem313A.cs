using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC313;

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
    /// To Be Saikyo
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var P = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0;
        if (N > 1)
        {
            var max = P.Skip(1).Max();
            ans = Math.Max(max - P[0] + 1, 0);
        }

        _writer.WriteLine(ans);
    }
}
