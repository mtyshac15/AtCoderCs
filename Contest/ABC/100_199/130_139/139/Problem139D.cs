using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC139;

public class ProblemD
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
    {
    }

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        // 1からN-1までの和
        var ans = (long)(N - 1) * N / 2;
        _writer.WriteLine(ans);
    }
}
