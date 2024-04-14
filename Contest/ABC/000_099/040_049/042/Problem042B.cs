using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC042;

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
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var NL = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NL[0];
        var L = NL[1];

        var S = new string[N];
        for (int i = 0; i < N; i++)
        {
            S[i] = Console.ReadLine().Trim();
        }

        Array.Sort(S);

        var ans = string.Join("", S);
        _writer.WriteLine(ans);
    }
}
