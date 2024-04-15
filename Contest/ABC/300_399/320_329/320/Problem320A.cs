using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC320;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Leyland Number
    /// </summary>
    public void Solve()
    {
        var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = AB[0];
        var B = AB[1];

        var ans = 0L;

        {
            var num = 1L;
            for (int i = 0; i < B; i++)
            {
                num *= A;
            }

            ans += num;
        }

        {
            var num = 1L;
            for (int i = 0; i < A; i++)
            {
                num *= B;
            }

            ans += num;
        }

        _writer.WriteLine(ans);
    }
}
