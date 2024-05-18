using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC333;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var count = 1;

        for (int d = 1; d <= 12; d++)
        {
            for (int a = d - 1; a >= 0; a--)
            {
                for (int b = d - a - 1; b >= 0; b--)
                {
                    if (count == N)
                    {
                        var c = d - a - b;
                        var ans = new string('1', a) + new string('2', b) + new string('3', c);
                        _writer.WriteLine(ans);
                        return;
                    }

                    count++;
                }
            }
        }
    }
}
