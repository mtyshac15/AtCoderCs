using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC327;

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
    /// A^A
    /// </summary>
    public void Solve()
    {
        var B = _reader.ReadLine().Trim().Split().Select(long.Parse).ToList()[0];

        var A = 1L;

        var ans = 0L;
        while (true)
        {
            var value = A;
            for (int i = 1; i < A; i++)
            {
                value *= A;
            }

            if (value == B)
            {
                ans = A;
                break;
            }
            else if (value > B)
            {
                ans = -1;
                break;
            }

            A++;
        }

        _writer.WriteLine(ans);
    }
}
