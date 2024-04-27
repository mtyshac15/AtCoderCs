using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC347;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = input[0];
        var B = input[1];
        var D = input[2];

        var list = new List<int>();

        var result = A;
        while (result <= B)
        {
            list.Add(result);
            result += D;
        }

        var ans = string.Join(" ", list);
        _writer.WriteLine(ans);
    }
}
