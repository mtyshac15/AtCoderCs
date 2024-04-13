using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderCs.Contest.ABC312;

public class ProblemA
{
    public static void Main(string[] args)
    {
        var problem = new ProblemA();
        problem.Solve();
    }

    /// <summary>
    /// Chord
    /// </summary>
    public void Solve()
    {
        var S = Console.ReadLine().Trim();

        var array = new string[]
        {
            "ACE","BDF","CEG","DFA","EGB","FAC","GBD"
        };

        var ans = array.Contains(S);
        Console.WriteLine(ProblemA.ToYesOrNo(ans));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }
}
