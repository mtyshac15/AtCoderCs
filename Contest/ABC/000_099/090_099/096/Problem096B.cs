using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC096;

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

    public void Solve()
    {
        var ABC = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var K = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var max = ABC.Max();
        var maxProduct = max;
        for (int i = 0; i < K; i++)
        {
            maxProduct *= 2;
        }

        var ans = ABC.Sum() - max + maxProduct;
        _writer.WriteLine(ans);
    }
}
