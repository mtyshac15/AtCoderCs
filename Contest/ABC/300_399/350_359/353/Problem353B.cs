using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AtCoderCs.Contest.ABC353;

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
        var NK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NK[0];
        var K = NK[1];
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var count = 1;
        var current = 0;
        var total = 0;

        while (current < N)
        {
            if (total + A[current] <= K)
            {
                total += A[current];
                current++;
            }
            else
            {
                count++;
                total = 0;
            }
        }

        var ans = count;
        _writer.WriteLine(ans);
    }
}
