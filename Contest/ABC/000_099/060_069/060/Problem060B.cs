using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC060;

public class ProblemB
{
    private TextReader _reader;
    private TextWriter _writer;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemB();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemB()
    {
        _reader = Console.In;
        _writer = Console.Out;
    }

    public ProblemB(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Choose Integers
    /// </summary>
    public void Solve()
    {
        var ABC = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = ABC[0];
        var B = ABC[1];
        var C = ABC[2];

        var set = new HashSet<int>();

        var total = A % B;

        //余りが一巡するまでに、Cと等しくならなければNo
        var ans = false;
        while (set.Add(total))
        {
            if (total == C)
            {
                ans = true;
                break;
            }

            total += A;
            total %= B;
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"YES" : $"NO";
        }
    }
}
