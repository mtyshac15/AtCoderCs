using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC101;

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

    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var ans = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == '+')
            {
                ans++;
            }
            else if (S[i] == '-')
            {
                ans--;
            }
        }

        _writer.WriteLine(ans);
    }
}
