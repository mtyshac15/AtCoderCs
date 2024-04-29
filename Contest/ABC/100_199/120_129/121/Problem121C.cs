using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC121;

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

    /// <summary>
    /// Energy Drink Collector
    /// </summary>
    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var A = new int[N];
        var B = new int[N];

        for (int i = 0; i < N; i++)
        {
            var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            A[i] = AB[0];
            B[i] = AB[1];
        }

        var array = A.Zip(B, (a, b) => (a, b)).OrderBy(x => x.a).ToArray();

        //最小額のものから買えるだけ買う
        var count = 0;
        var ans = 0L;

        for (var i = 0; i < N; i++)
        {
            var a = array[i].a;
            var b = array[i].b;

            var num = Math.Min(b, M - count);
            ans += (long)a * num;
            count += num;

            if (count == M)
            {
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
