using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC076;

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
    /// Addition and Multiplication
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var K = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var num = 1;
        for (int i = 0; i < N; i++)
        {
            if (num < K)
            {
                num *= 2;
            }
            else
            {
                num += K;
            }
        }

        var ans = num;
        _writer.WriteLine(ans);
    }
}
