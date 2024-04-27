using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC336;

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

    /// <summary>
    /// Long Loong
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var strBuilder = new StringBuilder();
        strBuilder.Append("L");

        for (int i = 0; i < N; i++)
        {
            strBuilder.Append("o");
        }

        strBuilder.Append("n");
        strBuilder.Append("g");

        var ans = strBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
