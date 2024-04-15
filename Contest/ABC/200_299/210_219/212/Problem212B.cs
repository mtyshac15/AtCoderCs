using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC212;

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
    /// Weak Password
    /// </summary>
    public void Solve()
    {
        var X = _reader.ReadLine().Trim().Select(x => int.Parse(x.ToString())).ToArray();

        //4桁とも同じ数字
        if (X[0] == X[1]
            && X[1] == X[2]
            && X[2] == X[3])
        {
            _writer.WriteLine("Weak");
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            var nextNum = (X[i] + 1) % 10;
            if (X[i + 1] != nextNum)
            {
                _writer.WriteLine("Strong");
                return;
            }
        }

        _writer.WriteLine("Weak");
    }
}
