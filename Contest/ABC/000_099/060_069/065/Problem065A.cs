using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC065;

public class ProblemA
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Expired?
    /// </summary>
    public void Solve()
    {
        var XAB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var X = XAB[0];
        var A = XAB[1];
        var B = XAB[2];

        var ans = string.Empty;
        if (-A + B <= 0)
        {
            ans = "delicious";
        }
        else if (-A + B <= X)
        {
            ans = "safe";
        }
        else
        {
            ans = "dangerous";
        }

        _writer.WriteLine(ans);
    }
}
