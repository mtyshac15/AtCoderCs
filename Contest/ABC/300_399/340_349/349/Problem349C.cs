using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC349;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Airport Code
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();
        var T = _reader.ReadLine().Trim();

        var t = T.ToLower();
        if (t[t.Length - 1] == 'x')
        {
            t = t.Substring(0, 2);
        }

        var ans = false;

        var tIndex = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == t[tIndex])
            {
                tIndex++;

                if (tIndex == t.Length)
                {
                    ans = true;
                    break;
                }
            }
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
