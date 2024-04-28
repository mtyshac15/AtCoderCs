using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC344;

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
    /// A+B+C
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var M = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var B = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var L = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var C = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var Q = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var X = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var AB = new HashSet<int>();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                AB.Add(A[i] + B[j]);
            }
        }

        for (int i = 0; i < Q; i++)
        {
            var ans = false;
            for (int j = 0; j < L; j++)
            {
                if (AB.Contains(X[i] - C[j]))
                {
                    ans = true;
                    break;
                }
            }

            _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
        }
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
