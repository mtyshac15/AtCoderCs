using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC343;

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
    /// 343
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray()[0];

        var cube = new List<long>();
        for (var x = 1L; x * x * x <= N; x++)
        {
            cube.Add(x * x * x);
        }

        cube.Sort();

        var ans = 0L;

        //回文
        for (int i = 0; i < cube.Count; i++)
        {
            var k = cube[cube.Count - 1 - i];
            var kStr = k.ToString();

            var isPalindrome = true;

            for (int j = 0; j < kStr.Length / 2; j++)
            {
                if (kStr[j] != kStr[kStr.Length - 1 - j])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                ans = k;
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
