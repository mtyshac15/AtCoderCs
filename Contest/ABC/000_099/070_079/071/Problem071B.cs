using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC071;

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
    /// Not Found
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();
        var charSet = new HashSet<char>(S);

        var ans = "None";
        for (int i = 0; i < 26; i++)
        {
            var str = (char)('a' + i);
            if (!charSet.Contains(str))
            {
                ans = str.ToString();
                break;
            }
        }

        _writer.WriteLine(ans);
    }
}
