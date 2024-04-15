using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC328;

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
    /// Not Too Hard
    /// </summary>
    public void Solve()
    {
        var NX = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NX[0];
        var X = NX[1];

        var S = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = S.Where(x => x <= X).Sum();
        _writer.WriteLine(ans);
    }
}
