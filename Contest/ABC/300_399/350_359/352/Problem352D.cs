using System;
using System.Collections.Generic;
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
        var descSet = new SortedSet<int>();

        var ans = int.MaxValue;
        var prevIndex = 0;

        for (int i = 0; i < N; i++)
        {
            var current = sortedP[i];
            ascSet.Add(current.i);
            descSet.Add(current.i * (-1));

            if (ascSet.Count == K + 1)
            {
                var prev = sortedP[prevIndex];
                ascSet.Remove(prev.i);
                descSet.Remove(prev.i * (-1));
                prevIndex++;
            }

            if (ascSet.Count == K)
            {
                var min = ascSet.FirstOrDefault();
                var max = descSet.FirstOrDefault() * (-1);
                ans = Math.Min(max - min, ans);
            }
        }

        _writer.WriteLine(ans);
    }
}
