using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC347;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var NAB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NAB[0];
        var A = NAB[1];
        var B = NAB[2];

        var D = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var list = new List<int>();

        for (int i = 0; i < N; i++)
        {
            var d = D[i] % (A + B);
            list.Add(d);
        }

        list.Sort();

        //2周目
        for (int i = 0; i < N; i++)
        {
            var d = list[i] + A + B;
            list.Add(d);
        }

        var ans = false;

        //各日を始点として、N先の日の差がA以下である日が存在すればtrue
        for (int i = 0; i < N; i++)
        {
            var start = list[i];
            var end = list[i + N - 1];

            if (end - start < A)
            {
                ans = true;
                break;
            }
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
