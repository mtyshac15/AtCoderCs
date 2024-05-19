using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC352;

public class ProblemC
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Standing On The Shoulders
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var A = new long[N];
        var B = new long[N];
        for (int i = 0; i < N; i++)
        {
            var AB = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();
            A[i] = AB[0];
            B[i] = AB[1];
        }

        //肩から頭までの高さの最大値を求める
        var head = A.Zip(B, (a, b) => b - a).Max();

        //全員の肩の高さの和+頭の高さの最大値
        var ans = A.Sum() + head;
        _writer.WriteLine(ans);
    }
}
