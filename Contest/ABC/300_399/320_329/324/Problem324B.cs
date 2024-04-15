using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC324;

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
    /// 3-smooth Numbers
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var ans = true;

        var value = N;
        foreach (var num in new int[] { 2, 3 })
        {
            while (true)
            {
                var remainder = value % num;
                if (remainder != 0)
                {
                    break;
                }

                value = value / num;
            }
        }

        if (value != 1)
        {
            ans = false;
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
