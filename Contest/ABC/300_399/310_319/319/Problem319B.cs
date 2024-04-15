using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC319;

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
    /// Measure
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var divisorList = new List<int>();
        for (int j = 1; j < 10; j++)
        {
            if (N % j == 0)
            {
                divisorList.Add(j);
            }
        }

        var list = new List<string>()
        {
            "1"
        };

        for (int i = 1; i <= N; i++)
        {
            foreach (var j in divisorList)
            {
                if (i % (N / j) == 0)
                {
                    list.Add(j.ToString());
                    break;
                }
            }

            if (list.Count == i)
            {
                list.Add("-");
            }
        }

        var ans = string.Join("", list);
        _writer.WriteLine(ans);
    }
}
