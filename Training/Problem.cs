using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Training;

public class Problem
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new Problem();
        problem.Solve();
        Console.Out.Flush();
    }

    public Problem()
    {
    }

    public Problem(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var x = new int[N];
        var y = new int[N];

        for (int i = 0; i < N; i++)
        {
            var xy = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            x[i] = xy[0];
            y[i] = xy[1];
        }

        var vectorSet = new HashSet<string>();

        for (int i = 0; i < N; i++)
        {
            vectorSet.Add($"{x[i]} {y[i]}");
        }

        var ans = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                //2点を指定し、正方形を成す残りの2点が存在するかを調べる
                var xq = x[j] - y[j] + y[i];
                var yq = y[j] + x[j] - x[i];

                var xr = x[i] - y[j] + y[i];
                var yr = y[i] + x[j] - x[i];

                if (vectorSet.Contains($"{xq} {yq}")
                    && vectorSet.Contains($"{xr} {yr}"))
                {
                    var square = (x[j] - x[i]) * (x[j] - x[i]) + (y[j] - y[i]) * (y[j] - y[i]);

                    ans = Math.Max(square, ans);
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
