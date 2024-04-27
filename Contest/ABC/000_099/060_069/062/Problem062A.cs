using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC062;

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
    /// Grouping
    /// </summary>
    public void Solve()
    {
        var xy = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var x = xy[0];
        var y = xy[1];

        var groupA = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        var groupB = new int[] { 4, 6, 9, 11 };
        var groupC = new int[] { 2 };

        var ans = groupA.Contains(x) && groupA.Contains(y)
            || groupB.Contains(x) && groupB.Contains(y);
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
