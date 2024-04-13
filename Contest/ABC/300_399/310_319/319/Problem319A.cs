using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC319;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Legendary Players
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();

        var players = "tourist 3858 ksun48 3679 Benq 3658 Um_nik 3648 apiad 3638 Stonefeang 3630 ecnerwala 3613 mnbvmar 3555 newbiedmy 3516 semiexp 3481".Split();
        var index = Array.IndexOf(players, S);

        var ans = players[index + 1];
        Console.WriteLine(ans);
    }
}
