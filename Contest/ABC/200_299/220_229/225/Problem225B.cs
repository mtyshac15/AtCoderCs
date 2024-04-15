using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC225;

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
    /// Star or Not
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];

        // 各ノードの次数を数える
        var count = new int[N + 1];

        var tree = new Dictionary<int, int>();

        for (int i = 0; i < N - 1; i++)
        {
            var tmp = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var a = tmp[0];
            var b = tmp[1];

            count[a]++;
            count[b]++;
        }

        //最大の辺を持つノードの辺の本数がN-1のときスター
        var isStar = count.Max() == N - 1;
        _writer.WriteLine(IOLibrary.ToYesOrNo(isStar));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
