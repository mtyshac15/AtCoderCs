using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC116;

public class MySolution
{
    public void OldB()
    {
        var N = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var h = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        var ans = h.Zip(h.Prepend(0), (e1, e2) => e1 - e2)
                   .Where(e => e > 0)
                   .Sum();

        Console.WriteLine(ans);
    }
}
