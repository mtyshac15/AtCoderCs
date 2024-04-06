using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC039;

public class ProblemC
{
    public static void Main(string[] args)
    {
        var problem = new ProblemC();
        problem.Solve();
    }

    public void Solve()
    {
        var S = Console.ReadLine().Trim();

        var totalWCount = 0;
        var wCount = 0;

        //最初にWが2つ連続してから次にW2が連続するまでのWの個数を数える

        var isStart = false;
        for (int i = 0; i < S.Length - 1; i++)
        {
            if (S[i] == 'W')
            {
                totalWCount++;

                if (isStart)
                {
                    wCount++;
                }

                if (S[i + 1] == 'W')
                {
                    if (!isStart)
                    {
                        isStart = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        var keybord = new string[7]
        {
            "Do","Re","Mi","Fa","So","La","Si"
        };

        var index = 0;
        if (wCount == 4)
        {
            //ド、レ、ミ
            index = 7 - totalWCount;
        }
        else if (wCount == 3)
        {
            //ファ、ソ、ラ、シ
            index = 10 - totalWCount;
        }

        var ans = keybord[index];
        Console.WriteLine(ans);
    }
}
