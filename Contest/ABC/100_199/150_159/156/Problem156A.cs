using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC156;

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
    /// Beginner
    /// </summary>
    public void Solve()
    {
        var NR = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NR[0];
        var R = NR[1];

        var ans = R;
        if (N < 10)
        {
            ans = R + 100 * (10 - N);
        }

        _writer.WriteLine(ans);
    }
}
