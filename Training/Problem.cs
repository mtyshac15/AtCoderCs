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
        var n = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var q = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var m = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var bit = 1L << n;
        for (int i = 0; i < q; i++)
        {
            var isMatch = false;
            for (int j = 0; j <= bit; j++)
            {
                var sum = 0;
                for (int k = 0; k < n; k++)
                {
                    if (((j >> k) & 1) == 1)
                    {
                        sum += A[k];
                    }
                }

                if (sum == m[i])
                {
                    isMatch = true;
                    break;
                }
            }

            var ans = IOLibrary.ToYesOrNo(isMatch);
            _writer.WriteLine(ans);
        }
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"yes" : $"no";
        }
    }
}
