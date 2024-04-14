using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC045;

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
        var SA = _reader.ReadLine().Trim();
        var SB = _reader.ReadLine().Trim();
        var SC = _reader.ReadLine().Trim();

        var prayers = "ABC";
        var cards = new Queue<char>[]
        {
            new Queue<char>(SA),
            new Queue<char>(SB),
            new Queue<char>(SC),
        };

        var turn = 0;
        while (cards[turn].Any())
        {
            var card = cards[turn].Dequeue();
            turn = prayers.IndexOf(card.ToString().ToUpper());
        }

        var ans = prayers[turn];
        _writer.WriteLine(ans);
    }
}
