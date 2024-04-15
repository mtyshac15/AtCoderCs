using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC325;

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
    /// World Meeting
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var WX = new int[N, 2];

        for (var i = 0; i < N; i++)
        {
            var array = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            WX[i, 0] = array[0];
            WX[i, 1] = array[1];
        }

        var ans = 0;

        //標準時に換算
        for (int t = 0; t < 24; t++)
        {
            var count = 0;
            for (var i = 0; i < N; i++)
            {
                var start = (t + WX[i, 1]) % 24;
                var end = start + 1;
                if (start >= 9 && end <= 18)
                {
                    count += WX[i, 0];
                }
            }

            ans = Math.Max(count, ans);
        }

        _writer.WriteLine(ans);
    }
}
