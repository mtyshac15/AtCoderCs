using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC330;

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
    /// Counting Passes
    /// </summary>
    public void Solve()
    {
        var NL = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NL[0];
        var L = NL[1];

        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = A.Count(x => x >= L);
        _writer.WriteLine(ans);
    }
}
