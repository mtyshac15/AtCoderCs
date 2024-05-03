using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC083;

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
    /// Some Sums
    /// </summary>
    public void Solve()
    {
        var NAB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NAB[0];
        var A = NAB[1];
        var B = NAB[2];

        var ans = 0;
        for (int i = 1; i <= N; i++)
        {
            var sum = i.ToString().ToCharArray().Sum(x => int.Parse(x.ToString()));
            if (sum >= A && sum <= B)
            {
                ans += i;
            }
        }

        _writer.WriteLine(ans);
    }
}
