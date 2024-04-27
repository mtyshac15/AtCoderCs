using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC340;

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
        var N = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        // 2^k < N <= 2^(k+1) を満たすk
        var k = 0;
        {
            //k=log2N
            var tmpN = N;
            var basis = 2;
            while (tmpN > 1)
            {
                tmpN /= basis;
                k++;
            }
        }

        var count = 1L;
        {
            //2^k
            var tmpK = k;
            var basis = 2L;
            while (tmpK > 0)
            {
                //指定したビットが1の場合に
                if ((tmpK & (1 << 0)) > 0)
                {
                    count *= basis;
                }

                basis *= basis;
                tmpK >>= 1;
            }
        }

        // 深さ 0 から k-1 までのノードの和はN
        // 2^kから1増えるごとに、深さ k のノードに 2が 1つずつ増える
        var result = N * k + 2 * (N - count);
        _writer.WriteLine(result);
    }
}
