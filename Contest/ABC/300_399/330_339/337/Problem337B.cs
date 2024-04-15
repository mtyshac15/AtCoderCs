using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC337;

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
    /// Extended ABC
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var current = 'A';

        foreach (var c in S)
        {
            if (current == 'A')
            {
                if (c == 'B' || c == 'C')
                {
                    current = c;
                }
            }
            else if (current == 'B')
            {
                if (c == 'A')
                {
                    _writer.WriteLine(IOLibrary.ToYesOrNo(false));
                    return;
                }
                else if (c == 'C')
                {
                    current = c;
                }
            }
            else if (current == 'C')
            {
                if (c != 'C')
                {
                    _writer.WriteLine(IOLibrary.ToYesOrNo(false));
                    return;
                }
            }
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(true));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
