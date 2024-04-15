using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC267;

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
    /// Split?
    /// </summary>
    public void Solve()
    {
        var S = _reader.ReadLine().Trim();
        var pins = S.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

        if (pins[0] == 1)
        {
            _writer.WriteLine(IOLibrary.ToYesOrNo(false));
            return;
        }

        //各列のピンがすべて倒れているか
        var split = new int[7];
        split[0] = pins[6];
        split[1] = pins[3];
        split[2] = pins[1] + pins[7];
        split[3] = pins[4];
        split[4] = pins[2] + pins[8];
        split[5] = pins[5];
        split[6] = pins[9];

        var pinExists = false;
        var emptyCount = 0;
        for (int i = 0; i < split.Length; i++)
        {
            if (!pinExists)
            {
                if (emptyCount == 0 && split[i] > 0)
                {
                    //ピンが立っている端の列
                    pinExists = true;
                }
            }
            else
            {
                if (split[i] > 0)
                {
                    if (emptyCount > 0)
                    {
                        //ピンがすでに立っており、間に空列が存在した場合
                        pinExists = false;
                    }
                }
                else
                {
                    emptyCount++;
                }
            }
        }

        var ans = !pinExists && emptyCount > 0;
        _writer.WriteLine(IOLibrary.ToYesOrNo(ans));
    }

    public static class IOLibrary
    {
        public static string ToYesOrNo(bool value)
        {
            return value ? $"Yes" : $"No";
        }
    }
}
