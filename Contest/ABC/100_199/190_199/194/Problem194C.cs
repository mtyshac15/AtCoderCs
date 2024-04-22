using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC194;

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
    /// Squared Error
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();

        var sumA = A.Sum();
        var squaredA = A.Select(x => x * x).ToArray();
        var squaredSumA = squaredA.Sum();

        var ans = 0L;
        for (int i = 0; i < N - 1; i++)
        {
            ans += (N - i - 1L) * squaredA[i] - 2 * A[i] * (sumA - A[i]) + squaredSumA - squaredA[i];
            sumA -= A[i];
            squaredSumA -= squaredA[i];

        }

        _writer.WriteLine(ans);
    }
}
