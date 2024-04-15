using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC328;

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
    /// 11/11
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var D = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = 0;
        for (int i = 1; i <= N; i++)
        {
            var iArray = i.ToString().Distinct().Distinct().ToArray();
            if (iArray.Length == 1)
            {
                var month = iArray[0];
                for (int j = 1; j <= D[i - 1]; j++)
                {
                    var jArray = j.ToString().Distinct().ToArray();
                    if (jArray.Length == 1)
                    {
                        var day = jArray[0];
                        if (month == day)
                        {
                            ans++;
                        }
                    }
                }
            }
        }

        _writer.WriteLine(ans);
    }
}
