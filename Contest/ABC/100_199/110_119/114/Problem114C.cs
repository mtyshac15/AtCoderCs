using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC114;

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
    /// 755
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var digits = N.ToString().Length;

        var array = new int[] { 3, 5, 7 };

        var ans = 0;
        //3桁から Nの桁数まで、7,5,3を組み合わせた数を求める
        for (int i = 3; i <= digits; i++)
        {
            // 357でi桁の数を作る場合、3^i
            var max = 1;
            for (int j = 0; j < i; j++)
            {
                max *= 3;
            }

            for (int j = 0; j < max; j++)
            {
                var numArray = new int[i];

                //3進数に変換
                var numJ = j;
                for (int k = 0; k < numArray.Length; k++)
                {
                    var index = numJ % 3;
                    numArray[k] = array[index];
                    numJ /= 3;
                }

                //357がすべて含まれているか判定
                if (numArray.Distinct().Count() == 3)
                {
                    //N以下かどうか判定
                    var num = int.Parse(string.Join("", numArray));
                    if (num <= N)
                    {
                        ans++;
                    }
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
