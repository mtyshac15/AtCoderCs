using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC071;

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
    /// Meal Delivery
    /// </summary>
    public void Solve()
    {
        var xab = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var x = xab[0];
        var a = xab[1];
        var b = xab[2];

        var ans = "A";
        var da = Math.Abs(x - a);
        var db = Math.Abs(x - b);
        if (da > db)
        {
            ans = "B";
        }

        _writer.WriteLine(ans);
    }
}
