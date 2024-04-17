using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AtCoderCs.Contest.ABC049;

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
        var HW = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        var H = HW[0];
        var W = HW[1];

        var C = new string[H];
        for (int i = 0; i < H; i++)
        {
            C[i] = _reader.ReadLine().Trim();
        }

        var ansBuilder = new StringBuilder();
        for (int i = 0; i < H; i++)
        {
            ansBuilder.AppendLine(C[i]);
            ansBuilder.AppendLine(C[i]);
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
