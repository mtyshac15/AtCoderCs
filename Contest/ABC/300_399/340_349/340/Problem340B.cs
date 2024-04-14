using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AtCoderCs.Contest.ABC340;

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
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var Q = input[0];

        var list = new List<long>();

        var strtBuilder = new StringBuilder();

        for (var i = 0; i < Q; i++)
        {
            var query = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var x = query[0];
            var k = query[1];

            if (x == 1)
            {
                list.Add(k);
            }
            else if (x == 2)
            {
                var result = list[list.Count - k];
                strtBuilder.AppendLine($"{result}");
            }
        }

        var ans = strtBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
