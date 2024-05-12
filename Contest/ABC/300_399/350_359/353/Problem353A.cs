using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC353;

public class ProblemA
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var H = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var hArray = H.Select((x, i) => (x, i)).Skip(1).ToArray();
        var ans = -1;
        if (hArray.Any(x => x.x > H[0]))
        {
            ans = hArray.FirstOrDefault(x => x.x > H[0]).i + 1;
        }

        _writer.WriteLine(ans);
    }
}
