using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC002;

public class ProblemD
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var x = new int[M];
        var y = new int[M];
        for (int i = 0; i < M; i++)
        {
            var xy = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            x[i] = xy[0];
            y[i] = xy[1];
        }

        var ans = 0;
        _writer.WriteLine(ans);
    }
}
