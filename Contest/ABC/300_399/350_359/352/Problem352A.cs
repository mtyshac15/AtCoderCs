using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC352;

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
    /// AtCoder Line
    /// </summary>
    public void Solve()
    {
        var NXYZ = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NXYZ[0];
        var X = NXYZ[1];
        var Y = NXYZ[2];
        var Z = NXYZ[3];

        var max = Math.Max(X, Y);
        var min = Math.Min(X, Y);

        var ans = Z < max && Z > min;
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
