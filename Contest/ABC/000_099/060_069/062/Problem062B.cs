using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC062;

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
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Picture Frame
    /// </summary>
    public void Solve()
    {
        var HW = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var H = HW[0];
        var W = HW[1];

        var a = new string[H];
        for (int i = 0; i < H; i++)
        {
            a[i] = _reader.ReadLine().Trim();
        }

        var mark = '#';

        var decorator = new string(Enumerable.Repeat(mark, W + 2).ToArray());

        var ansBuilder = new StringBuilder();
        ansBuilder.AppendLine(decorator);

        for (int i = 0; i < H; i++)
        {
            var newStr = new string(a[i].Prepend(mark).Append(mark).ToArray());
            ansBuilder.AppendLine(newStr);
        }

        ansBuilder.AppendLine(decorator);

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
