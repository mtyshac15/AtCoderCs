using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AtCoderCs.Contest.ABC351;

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

    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var A = new string[N];
        for (int i = 0; i < N; i++)
        {
            A[i] = _reader.ReadLine().Trim();
        }

        var B = new string[N];
        for (int i = 0; i < N; i++)
        {
            B[i] = _reader.ReadLine().Trim();
        }

        var ans = string.Empty;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (A[i][j] != B[i][j])
                {
                    ans = $"{i + 1} {j + 1}";
                    break;
                }
            }

            if (!string.IsNullOrWhiteSpace(ans))
            {
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
