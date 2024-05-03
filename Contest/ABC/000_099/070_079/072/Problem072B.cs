using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC072;

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

    /// <summary>
    /// OddString
    /// </summary>
    public void Solve()
    {
        var s = _reader.ReadLine().Trim();
        var array = s.Select((x, i) => (x, i))
                     .Where(x => x.i % 2 != 1)
                     .Select(x => x.x);

        var ans = string.Join("", array);
        _writer.WriteLine(ans);
    }
}
