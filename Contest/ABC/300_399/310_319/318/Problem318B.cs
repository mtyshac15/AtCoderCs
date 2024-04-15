using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC318;

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
    /// Overlapping sheets
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var area = new int[101, 101];

        for (int i = 0; i < N; i++)
        {
            var ABCD = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var A = ABCD[0];
            var B = ABCD[1];
            var C = ABCD[2];
            var D = ABCD[3];

            for (int x = A; x < B; x++)
            {
                for (int y = C; y < D; y++)
                {
                    area[x, y] = 1;
                }
            }
        }

        //面積を算出
        var ans = 0;
        for (int x = 0; x < area.GetLength(0); x++)
        {
            for (int y = 0; y < area.GetLength(1); y++)
            {
                ans += area[x, y];
            }
        }

        _writer.WriteLine(ans);
    }
}
