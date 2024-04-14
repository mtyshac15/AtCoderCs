using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC348;

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
    /// Farthest Point
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var XY = new int[N, 2];

        for (int i = 0; i < N; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            XY[i, 0] = input[0];
            XY[i, 1] = input[1];
        }

        var ansBuilder = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            var point = 0;
            int maxD2 = 0;
            for (int j = 0; j < N; j++)
            {
                var dx = XY[i, 0] - XY[j, 0];
                var dy = XY[i, 1] - XY[j, 1];
                var d2 = dx * dx + dy * dy;

                if (d2 > maxD2)
                {
                    point = j + 1;
                    maxD2 = d2;
                }
            }

            ansBuilder.AppendLine(point.ToString());
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
