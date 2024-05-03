using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC082;

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
    /// 
    /// </summary>
    public void Solve()
    {
        var s = _reader.ReadLine().Trim();
        var t = _reader.ReadLine().Trim();

        var sArray = s.ToCharArray();
        Array.Sort(sArray);

        var tArray = t.ToCharArray();
        Array.Sort(tArray);
        tArray = tArray.Reverse().ToArray();

        var ans = false;
        if (sArray.Length < tArray.Length)
        {
            ans = sArray.SequenceEqual(tArray.Take(sArray.Length));
        }

        if (!ans)
        {
            var length = Math.Min(sArray.Length, tArray.Length);
            for (int i = 0; i < length; i++)
            {
                if (sArray[i] < tArray[i])
                {
                    ans = true;
                    break;
                }
                else if (sArray[i] > tArray[i])
                {
                    ans = false;
                    break;
                }
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
