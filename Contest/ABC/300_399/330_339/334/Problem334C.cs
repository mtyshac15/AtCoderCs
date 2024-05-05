using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace AtCoderCs.Contest.ABC334;

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
        var NK = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NK[0];
        var K = NK[1];

        var A = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();

        //階差数列
        var B = A.Skip(1).Zip(A, (b1, b2) => b1 - b2)
                         .ToArray();

        //階差数列の添え字が偶数の累積和
        var sumBEven = new List<long>() { 0 };

        //階差数列の添え字が奇数の累積和
        var sumBOdd = new List<long>() { 0 };

        for (var i = 0; i < K - 1; i++)
        {
            if (i % 2 == 0)
            {
                var last = sumBEven[sumBEven.Count - 1];
                sumBEven.Add(last + B[i]);
            }
            else
            {
                var last = sumBOdd[sumBOdd.Count - 1];
                sumBOdd.Add(last + B[i]);
            }
        }

        var ans = 0L;
        if (K % 2 == 0)
        {
            //階差数列の添え字が偶数の和
            ans = sumBEven[sumBEven.Count - 1];
        }
        else
        {
            ans = long.MaxValue;

            //階差数列の添え字が偶数の要素を除外
            for (int i = 0; i < K; i += 2)
            {
                //除外した数より前の数値は添え字が偶数
                var sum = sumBEven[i / 2];

                //除外した数より後の数値は添え字が奇数
                sum += sumBOdd[sumBOdd.Count - 1] - sumBOdd[(i + 1) / 2];

                ans = Math.Min(sum, ans);
            }
        }

        _writer.WriteLine(ans);
    }
}
