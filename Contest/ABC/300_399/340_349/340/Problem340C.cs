using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC340;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    public void Solve()
    {
        var input = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        var N = input[0];

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
        Console.WriteLine(result);
    }
}
