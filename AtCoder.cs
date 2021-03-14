using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class AtCoder
{
    static void Main(string[] args)
    {
        Action method = null;
        ProblemBase problem;

        problem = new ABC195.Problem();

        //method = problem.SolveA;
        method = problem.SolveB;
        //method = problem.SolveC;
        //method = problem.SolveD;
        //method = problem.SolveE;
        //method = problem.SolveF;

        //AtCoder.ExecuteByStandardIO(method);
        AtCoder.ExecuteByFileIO(method);
    }

    public static void ExecuteByStandardIO(Action method)
    {
        string input;
        do
        {
            AtCoder.Timer("", method);

            Console.WriteLine();
            Console.WriteLine("Continue? 1:Yes, others:No");
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

                AtCoder.Timer("", method);
            }

            Console.WriteLine();
            Console.WriteLine("Continue? 1:Yes, others:No");
            input = Console.ReadLine();
        } while (input == "1");
    }

    public static void Timer(string text, Action method)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();

        method?.Invoke();

        sw.Stop();
        var secondTime = (int)(sw.Elapsed.TotalMilliseconds);

        Console.WriteLine();
        Console.WriteLine($"{text}: {secondTime} ms");
    }
}
