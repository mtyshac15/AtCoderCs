using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC350;

public class ProblemC
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var K = 0;
        var ansBuilder = new StringBuilder();

        var index = 0;
        while (index < N)
        {
            var num = index + 1;
            if (A[index] != num)
            {
                var iIndex = index;
                var jIndex = A[index] - 1;

                var tmp = A[iIndex];
                A[iIndex] = A[jIndex];
                A[jIndex] = tmp;

                var indexes = new int[] { iIndex + 1, jIndex + 1 };
                ansBuilder.AppendLine($"{indexes.Min()} {indexes.Max()}");
                K++;
            }
            else
            {
                index++;
            }
        }

        _writer.WriteLine(K);
        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
