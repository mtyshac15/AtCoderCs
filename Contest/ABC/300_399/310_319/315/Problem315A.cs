using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC315;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// tcdr
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var strArray = "aeiou";

        var ans = S;
        foreach (var s in strArray)
        {
            ans = ans.Replace(s.ToString(), string.Empty);
        }

        _writer.WriteLine(ans);
    }
}
