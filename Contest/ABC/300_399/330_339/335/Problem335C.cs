using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC335;

public class ProblemC
{
    private TextReader _reader = Console.In;
    private TextWriter _writer = Console.Out;

    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        var problem = new ProblemC();
        problem.Solve();
        Console.Out.Flush();
    }

    public ProblemC()
    {
    }

    public ProblemC(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var NQ = _reader.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var N = NQ[0];
        var Q = NQ[1];

        var queryArray = new string[Q];
        for (int i = 0; i < Q; i++)
        {
            queryArray[i] = _reader.ReadLine().Trim();
        }

        var headX = 1;
        var headY = 0;

        var headXList = new List<int>();
        var headYList = new List<int>();

        var moveCount = 0;

        var ansBuilder = new StringBuilder();
        for (int i = 0; i < Q; i++)
        {
            var query = queryArray[i].Split();
            if (query[0] == "1")
            {
                switch (query[1])
                {
                    case "L":
                        headX--;
                        break;

                    case "R":
                        headX++;
                        break;

                    case "U":
                        headY++;
                        break;

                    case "D":
                        headY--;
                        break;
                }

                moveCount++;
                headXList.Add(headX);
                headYList.Add(headY);
            }
            else
            {
                var p = int.Parse(query[1]);

                var x = headX;
                var y = headY;
                if (moveCount < p)
                {
                    x = p - moveCount;
                    y = 0;
                }
                else
                {
                    x = headXList[moveCount - p];
                    y = headYList[moveCount - p];
                }

                ansBuilder.AppendLine($"{x} {y}");
            }
        }

        var ans = ansBuilder.ToString();
        _writer.WriteLine(ans);
    }
}
