using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AtCoderCs.Contest.ABC352;

public class ProblemB
{
    private TextReader _reader;
    private TextWriter _writer;

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
    /// Typing
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();
        var T = _reader.ReadLine().Trim();

        var list = new List<int>();

        var sIndex = 0;
        for (var i = 0; i < T.Length; i++)
        {
            if (T[i] == S[sIndex])
            {
                list.Add(i + 1);
                sIndex++;
            }
        }

        var ans = string.Join(" ", list);
        _writer.WriteLine(ans);
    }
}
