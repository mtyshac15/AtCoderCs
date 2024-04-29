using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC121;

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
    /// Can you solve this?
    /// </summary>
    public void Solve()
    {
        var NMC = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NMC[0];
        var M = NMC[1];
        var C = NMC[2];

        var B = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var A = new int[N][];
        for (int i = 0; i < N; i++)
        {
            A[i] = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        }

        var ans = 0;
        for (int i = 0; i < N; i++)
        {
            //内積
            var sum = A[i].Zip(B, (a, b) => a * b).Sum();
            sum += C;
            if (sum > 0)
            {
                ans++;
            }
        }

        _writer.WriteLine(ans);
    }
}
