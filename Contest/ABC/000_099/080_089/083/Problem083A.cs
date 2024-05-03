using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC083;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var ABCD = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = ABCD[0];
        var B = ABCD[1];
        var C = ABCD[2];
        var D = ABCD[3];

        var ans = string.Empty;
        if (A + B < C + D)
        {
            ans = "Right";
        }
        else if (A + B > C + D)
        {
            ans = "Left";
        }
        else
        {
            ans = "Balanced";
        }

        _writer.WriteLine(ans);
    }
}
