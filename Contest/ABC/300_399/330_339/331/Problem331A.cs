using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC331;

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
    /// Tomorrow
    /// </summary>
    public void Solve()
    {
        var MD = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var M = MD[0];
        var D = MD[1];

        var ymd = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var y = ymd[0];
        var m = ymd[1];
        var d = ymd[2];

        var newy = y;
        var newm = m;
        var newd = d + 1;

        if (newd == D + 1)
        {
            newd = 1;
            newm++;
        }

        if (newm == M + 1)
        {
            newm = 1;
            newy++;
        }

        var ans = string.Join(" ", newy, newm, newd);
        _writer.WriteLine(ans);
    }
}
