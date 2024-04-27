using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC350;

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
    /// Past ABCs
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();
        var number = int.Parse(S.Substring(S.Length - 3, 3));

        var ans = false;
        if (number == 316)
        {
            ans = false;
        }
        else
        {
            ans = 1 <= number && number < 350;
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
