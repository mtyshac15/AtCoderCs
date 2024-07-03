using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC088;

public class Problem088MySolution
{
    public void OldB()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Array.Sort(a);
        var sortedA = a.Reverse()
                       .Select((a, index) => new
                       {
                           Value = a,
                           Index = index,
                       });

        var AliceSum = sortedA.Where(a => a.Index % 2 == 0).Sum(a => a.Value);
        var BobSum = sortedA.Where(a => a.Index % 2 != 0).Sum(a => a.Value);

        var ans = AliceSum - BobSum;
        Console.WriteLine(ans);
    }
}
