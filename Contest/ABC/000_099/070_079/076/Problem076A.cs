using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC076;

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
    /// Rating Goal
    /// </summary>
    public void Solve()
    {
        var R = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var G = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 2 * G - R;
        _writer.WriteLine(ans);
    }
}
