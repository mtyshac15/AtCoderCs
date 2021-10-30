using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class AtCoderMain
{
    static void Main(string[] args)
    {
#if true
        AtCoderMain.SolveProblem();
#else
        AtCoderMain.SolveTypicalProblem();
#endif
    }

    private static void SolveProblem()
    {
        Action method = null;
        AtCoder.Common.ProblemBase problem;

        problem = new ABC225.Problem();

        //method = problem.SolveA;
        //method = problem.SolveB;
        //method = problem.SolveC;
        method = problem.SolveD;
        //method = problem.SolveE;
        //method = problem.SolveF;

        //AtCoder.ExecuteByStandardIO(method);
        AtCoderMain.ExecuteByFileIO(method);
    }

    private static void SolveTypicalProblem()
    {
        Action method = null;
        Typical.Problem.TypicalProblemBase problem;

        problem = new Typical.Problem064.Problem();

        method = problem.Solve;

        AtCoderMain.ExecuteByFileIO(method);
    }

    public static void ExecuteByStandardIO(Action method)
    {
        string input;
        do
        {
            AtCoderMain.Timer("", method);

            IOLibrary.WriteLine();
            IOLibrary.WriteLine("Continue? 1:Yes, others:No");
            input = Console.ReadLine();
        } while (input == "1");
    }

    public static void ExecuteByFileIO(Action method)
    {
        var textFile = @$"Text\Sample.txt";

        string input;

        do
        {
            using (var reader = new StreamReader(textFile))
            {
                IOLibrary.SetReadLineMethod(reader.ReadLine);

                AtCoderMain.Timer("", method);
            }

            IOLibrary.WriteLine();
            IOLibrary.WriteLine("Continue? 1:Yes, others:No");
            input = Console.ReadLine();
        } while (input == "1");
    }

    public static void Timer(string text, Action method)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();

        method?.Invoke();

        sw.Stop();
        var secondTime = (int)(sw.Elapsed.TotalMilliseconds);

        IOLibrary.WriteLine();
        IOLibrary.WriteLine($"{text}: {secondTime} ms");
    }
}
