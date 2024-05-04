using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC336;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Even Digits
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var evenArray = new List<int>();

        var tmpN = N - 1;
        while (tmpN > 0)
        {
            evenArray.Add((int)(tmpN % 5) * 2);
            tmpN /= 5;
        }

        var ans = string.Empty;
        if (evenArray.Any())
        {
            evenArray.Reverse();
            ans = string.Join("", evenArray);
        }
        else
        {
            ans = $"0";
        }

        _writer.WriteLine(ans);
    }
}
