using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC337;

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
    /// Scoreboard
    /// </summary>
    public void Solve()
    {
        var input = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = input[0];

        var sumX = 0;
        var sumY = 0;

        for (var i = 0; i < N; i++)
        {
            var XY = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            sumX += XY[0];
            sumY += XY[1];
        }

        if (sumX > sumY)
        {
            _writer.WriteLine("Takahashi");
            return;
        }
        else if (sumX < sumY)
        {
            _writer.WriteLine("Aoki");
            return;
        }

        _writer.WriteLine("Draw");
    }
}
