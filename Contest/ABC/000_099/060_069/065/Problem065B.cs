using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC065;

public class ProblemB
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Trained?
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var a = new int[N];

        for (int i = 0; i < N; i++)
        {
            a[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        }

        var count = 0;

        var button = 1;
        for (int i = 0; i < N; i++)
        {
            button = a[button - 1];

            count++;
            if (button == 2)
            {
                break;
            }
        }

        var ans = 0;
        if (button == 2)
        {
            ans = count;
        }
        else
        {
            ans = -1;
        }

        _writer.WriteLine(ans);
    }
}
