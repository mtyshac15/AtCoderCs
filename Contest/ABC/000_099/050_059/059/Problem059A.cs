using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC059;

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
    /// Three-letter acronym
    /// </summary>
    public void Solve()
    {
        var s = _reader.ReadLine().Trim().Split();
        var s1 = s[0];
        var s2 = s[1];
        var s3 = s[2];

        var ans = string.Join(string.Empty, s1[0], s2[0], s3[0]).ToUpper();
        _writer.WriteLine(ans);
    }
}
