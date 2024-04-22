using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC059;

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
    /// Comparison
    /// </summary>
    public void Solve()
    {
        var A = _reader.ReadLine().Trim();
        var B = _reader.ReadLine().Trim();

        var ans = "EQUAL";
        if (A.Length > B.Length)
        {
            ans = "GREATER";
        }
        else if (A.Length < B.Length)
        {
            ans = "LESS";
        }
        else
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > B[i])
                {
                    ans = "GREATER";
                    break;
                }
                else if (A[i] < B[i])
                {
                    ans = "LESS";
                    break;
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
