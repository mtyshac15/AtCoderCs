using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC039;

public class MySolution
{
    public void OldB()
    {
        var X = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray()[0];
        var ans = (int)Math.Sqrt((int)Math.Sqrt(X));
        Console.WriteLine(ans);
    }
}
