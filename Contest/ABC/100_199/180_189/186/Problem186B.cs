using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC186;

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
    /// Blocks on Grid
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = input[0];
        var W = input[1];

        var A = new int[H, W];

        for (int h = 0; h < H; h++)
        {
            var array = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            for (int w = 0; w < W; w++)
            {
                A[h, w] = array[w];
            }
        }

        var min = int.MaxValue;
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                min = Math.Min(A[h, w], min);
            }
        }

        var ans = 0;
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                ans += A[h, w] - min;
            }
        }

        _writer.WriteLine(ans);
    }
}
