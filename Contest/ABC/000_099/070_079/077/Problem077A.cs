using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC077;

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
    /// Rotation
    /// </summary>
    public void Solve()
    {
        var C = new string[2];
        for (int i = 0; i < 2; i++)
        {
            C[i] = _reader.ReadLine().Trim();
        }

        var ans = true;
        for (int i = 0; i < 3; i++)
        {
            if (C[0][i] != C[1][2 - i])
            {
                ans = false;
                break;
            }
        }

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
