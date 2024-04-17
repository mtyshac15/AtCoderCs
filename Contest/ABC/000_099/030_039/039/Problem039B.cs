using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC039;

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

    public void Solve()
    {
        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0;

        //200^4 = 1.6 * 10^9
        for (int i = 0; i < 200; i++)
        {
            if (i * i * i * i == X)
            {
                ans = i;
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
