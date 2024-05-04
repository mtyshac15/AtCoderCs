using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC352;

public class ProblemD
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemD();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemD()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemD(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Permutation Subsequence
    /// </summary>
    public void Solve()
    {
        var NK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NK[0];
        var K = NK[1];

        var P = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var sortedP = P.Select((p, i) => (p, i)).OrderBy(x => x.p).ToArray();

        var ascSet = new SortedSet<int>();
        var desSet = new SortedSet<int>();

        foreach (var num in sortedP.Take(K))
        {
            ascSet.Add(num.i + 1);
            desSet.Add((num.i + 1) * (-1));
        }

        var min = ascSet.FirstOrDefault();
        var max = desSet.FirstOrDefault() * (-1);
        var ans = max - min;

        var prevIndex = 0;
        for (int i = K; i < N; i++)
        {
            var prev = sortedP[prevIndex];
            var index = prev.i + 1;

            ascSet.Remove(index);
            desSet.Remove(index * (-1));

            var current = sortedP[i];
            ascSet.Add(current.i + 1);
            desSet.Add((current.i + 1) * (-1));

            min = ascSet.FirstOrDefault();
            max = desSet.FirstOrDefault() * (-1);
            ans = Math.Min(max - min, ans);

            prevIndex++;
        }

        _writer.WriteLine(ans);
    }
}
