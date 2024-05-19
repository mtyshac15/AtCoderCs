using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC128;

public class ProblemC
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var NM = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NM[0];
        var M = NM[1];

        var k = new int[M];
        var s = new int[M][];

        for (int i = 0; i < M; i++)
        {
            var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            k[i] = input[0];
            s[i] = input.Skip(1).ToArray();
        }

        var p = _reader.ReadLine().Trim().Split().Select(long.Parse).ToArray();

        var ans = 0;
        for (int bit = 0; bit < (1 << N); bit++)
        {
            var isAllOn = true;
            for (int i = 0; i < M; i++)
            {
                //Switch‚ªƒIƒ“‚Å‚ ‚éŒÂ”
                var onCount = 0;
                for (int j = 0; j < k[i]; j++)
                {
                    //“d‹…‚ª‚Â‚¢‚Ä‚¢‚é‚©‚Ç‚¤‚©
                    if ((bit >> (s[i][j] - 1) & 1) == 1)
                    {
                        onCount++;
                    }
                }

                if (onCount % 2 != p[i])
                {
                    isAllOn = false;
                    break;
                }
            }

            if (isAllOn)
            {
                ans++;
            }
        }

        _writer.WriteLine(ans);
    }
}
