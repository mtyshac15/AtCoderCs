using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC186;

public class MySolution
{
    public void OldC()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];

        var count = 0;

        for (int num = 1; num <= N; num++)
        {
            var sevenExists = false;

            var strNum = num.ToString();
            foreach (var str in strNum)
            {
                if (str == '7')
                {
                    //10進数で7を含む場合
                    sevenExists = true;
                    count++;
                    break;
                }
            }

            if (!sevenExists)
            {
                //10進数で7を含まない場合、8進数表記で7を含むか判定
                var eightList = new List<int>();

                var quotient = num;
                while (quotient > 0)
                {
                    var reminder = quotient % 8;
                    eightList.Add(reminder);
                    quotient = quotient / 8;
                }

                foreach (var str in eightList)
                {
                    if (str == 7)
                    {
                        count++;
                        break;
                    }
                }
            }
        }

        var ans = N - count;
        Console.WriteLine(ans);
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
