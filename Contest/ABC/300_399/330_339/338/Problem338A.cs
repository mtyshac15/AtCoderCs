using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC338;

public class ProblemA
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemA();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemA()
    {
    }

    public ProblemA(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    /// <summary>
    /// Capitalized?
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        var result = true;
        for (int i = 0; i < S.Length; i++)
        {
            var str = S[i];

            if (i == 0 && char.IsLower(str))
            {
                //先頭が小文字
                result = false;
            }
            else if (i != 0 && char.IsUpper(str))
            {
                //先頭以外が大文字
                result = false;
            }
        }

        _writer.WriteLine(IOLibrary.ToYesOrNo(result));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
