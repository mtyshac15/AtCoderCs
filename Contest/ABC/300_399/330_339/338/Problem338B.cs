using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC338;

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
    /// Frequency
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var dic = new Dictionary<char, int>();

        //文字の個数を算出
        foreach (char c in S)
        {
            if (!dic.ContainsKey(c))
            {
                dic.Add(c, 1);
            }
            else
            {
                dic[c]++;
            }
        }

        //個数でグルーピングし、同じ個数の文字のうち、アルファベット順で最も早い文字を取得
        var group = dic.GroupBy(x => x.Value);
        var maxNum = group.Max(x => x.Key);

        var list = new List<char>();

        foreach (var item in dic.Where(x => x.Value == maxNum))
        {
            list.Add(item.Key);
        }

        list.Sort();

        var ans = list.FirstOrDefault();

        _writer.WriteLine(ans);
    }
}
