using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC139;

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
    /// Power Socket
    /// </summary>
    public void Solve()
    {
        var AB = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var A = AB[0];
        var B = AB[1];

        //タップがn個のとき、差込口は A*n - (n-1)
        // (B-1)/(A-1)
        var ans = (A + B - 3) / (A - 1);
        _writer.WriteLine(ans);
    }
}
