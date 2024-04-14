using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC349;

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

    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var dic = new Dictionary<char, int>();

        for (int i = 0; i < S.Length; i++)
        {
            if (!dic.ContainsKey(S[i]))
            {
                dic.Add(S[i], 1);
            }
            else
            {
                dic[S[i]]++;
            }
        }

        var ans = true;
        for (int i = 1; i <= S.Length; i++)
        {
            var count = dic.Count(x => x.Value == i);
            if (count != 0 && count != 2)
            {
                ans = false;
                break;
            }
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
