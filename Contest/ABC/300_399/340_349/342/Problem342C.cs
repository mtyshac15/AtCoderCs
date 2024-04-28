using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace AtCoderCs.Contest.ABC342;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var S = _reader.ReadLine().Trim();
        var Q = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var c = new char[Q];
        var d = new char[Q];

        for (int i = 0; i < Q; i++)
        {
            var cd = _reader.ReadLine().Trim().Split().Select(char.Parse).ToArray();
            c[i] = cd[0];
            d[i] = cd[1];
        }

        var converter = new Dictionary<char, char>();

        for (int i = 0; i < Q; i++)
        {
            if (!converter.ContainsKey(c[i]))
            {
                converter.Add(c[i], d[i]);
            }

            foreach (var keyValue in converter.Where(x => x.Value == c[i]))
            {
                converter[keyValue.Key] = d[i];
            }
        }

        var charArray = new char[N];
        for (int i = 0; i < N; i++)
        {
            if (!converter.ContainsKey(S[i]))
            {
                charArray[i] = S[i];
            }
            else
            {
                charArray[i] = converter[S[i]];
            }
        }

        var ans = string.Join(string.Empty, charArray);
        _writer.WriteLine(ans);
    }
}
