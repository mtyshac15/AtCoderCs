using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC087;

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
    /// Coins
    /// </summary>
    public void Solve()
    {
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var B = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var C = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0;
        for (int a = 0; a <= A; a++)
        {
            for (int b = 0; b <= B; b++)
            {
                for (int c = 0; c <= C; c++)
                {
                    var total = 500 * a + 100 * b + 50 * c;
                    if (total == X)
                    {
                        ans++;
                    }
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
