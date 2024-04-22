using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC194;

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
    /// Job Assignment
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = new int[N];
        var B = new int[N];

        for (int i = 0; i < N; i++)
        {
            var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            A[i] = AB[0];
            B[i] = AB[1];
        }

        var ans = int.MaxValue;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                int time;
                if (i == j)
                {
                    time = A[i] + B[j];
                }
                else
                {
                    time = Math.Max(A[i], B[j]);
                }

                ans = Math.Min(time, ans);
            }
        }

        _writer.WriteLine(ans);
    }
}
