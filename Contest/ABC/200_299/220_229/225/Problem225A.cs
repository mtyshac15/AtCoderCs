using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC225;

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
    /// Distinct Strings
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();

        //文字種類の個数を算出
        var charSet = new HashSet<char>(S.ToCharArray());

        var ans = 6;
        if (charSet.Count == 1)
        {
            ans = 1;
        }
        else if (charSet.Count == 2)
        {
            //文字の種類が2種類のとき、同じ文字は2文字ある 3!/2!
            ans = 3;
        }

        _writer.WriteLine(ans);
    }
}
