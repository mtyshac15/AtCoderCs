using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC091;

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
    /// Two Colors Card Game
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var s = new string[N];
        for (int i = 0; i < N; i++)
        {
            s[i] = _reader.ReadLine().Trim();
        }

        var M = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var t = new string[M];
        for (int i = 0; i < M; i++)
        {
            t[i] = _reader.ReadLine().Trim();
        }

        var buleDictionary = new Dictionary<string, int>();
        for (int i = 0; i < N; i++)
        {
            if (!buleDictionary.ContainsKey(s[i]))
            {
                buleDictionary.Add(s[i], 1);
            }
            else
            {
                buleDictionary[s[i]]++;
            }
        }

        var redDictionary = new Dictionary<string, int>();
        for (int i = 0; i < M; i++)
        {
            if (!redDictionary.ContainsKey(t[i]))
            {
                redDictionary.Add(t[i], 1);
            }
            else
            {
                redDictionary[t[i]]++;
            }
        }

        var ans = 0;
        foreach (var blueKeyValue in buleDictionary)
        {
            if (redDictionary.ContainsKey(blueKeyValue.Key))
            {
                var red = redDictionary[blueKeyValue.Key];
                ans = Math.Max(blueKeyValue.Value - red, ans);
            }
            else
            {
                ans = Math.Max(blueKeyValue.Value, ans);
            }
        }

        _writer.WriteLine(ans);
    }
}
