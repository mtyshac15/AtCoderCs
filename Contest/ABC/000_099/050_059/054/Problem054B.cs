using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC054;

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

    /// <summary>
    /// Template Matching
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var A = new string[N];
        var B = new string[M];

        for (int i = 0; i < N; i++)
        {
            A[i] = _reader.ReadLine().Trim();
        }

        for (int i = 0; i < M; i++)
        {
            B[i] = _reader.ReadLine().Trim();
        }

        var ans = true;
        for (int ai = 0; ai < N - M; ai++)
        {
            for (int aj = 0; aj < N - M; aj++)
            {
                var isMatch = true;
                for (int bi = 0; bi < M; bi++)
                {
                    for (int bj = 0; bj < M; bj++)
                    {
                        if (A[ai + bi][aj + bj] != B[bi][bj])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (!isMatch)
                    {
                        break;
                    }
                }

                ans = isMatch;
                if (ans)
                {
                    break;
                }
            }

            if (ans)
            {
                break;
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
