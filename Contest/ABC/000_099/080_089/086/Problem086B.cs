using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC086;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var ab = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];

        var n = int.Parse($"{a}{b}");

        var ans = false;
        for (int i = 1; i * i <= n; i++)
        {
            if (i * i == n)
            {
                ans = true;
                break;
            }
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
