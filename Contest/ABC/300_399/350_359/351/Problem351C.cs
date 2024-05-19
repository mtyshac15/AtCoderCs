using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC351;

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
        var N = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var A = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var stack = new Stack<int>();
        stack.Push(A[0]);

        var index = 1;
        while (index < A.Length)
        {
            var current = A[index];
            var last = stack.Peek();
            if (current == last)
            {
                while (current == last)
                {
                    stack.Pop();
                    current++;

                    if (!stack.Any())
                    {
                        break;
                    }

                    last = stack.Peek();
                }

                stack.Push(current);
            }
            else
            {
                stack.Push(current);
            }

            index++;
        }

        var ans = stack.Count;
        _writer.WriteLine(ans);
    }
}
