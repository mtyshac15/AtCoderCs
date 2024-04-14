using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC043;

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

        var stack = new Stack<char>();
        foreach (char c in S)
        {
            if (c == 'B')
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(c);
            }
        }

        var ans = string.Join("", stack.Reverse());
        _writer.WriteLine(ans);
    }
}
