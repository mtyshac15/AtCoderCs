using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC064;

public class ProblemA
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// RGB Cards
    /// </summary>
    public void Solve()
    {
        var rgb = _reader.ReadLine().Trim().Split();
        var n = int.Parse(string.Join(string.Empty, rgb));

        var ans = n % 4 == 0;
        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"YES" : $"NO";
        }
    }
}
