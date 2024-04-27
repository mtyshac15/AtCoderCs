using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC336;

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
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var ans = 0;
        var tmpN = N;

        while (true)
        {
            var remainder = tmpN % 2;
            tmpN = tmpN / 2;

            if (remainder == 0)
            {
                ans++;
            }

            if (remainder == 1 || tmpN == 0)
            {
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
