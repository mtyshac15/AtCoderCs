using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs;

public class Program
{
    public static void Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        Console.Out.Flush();
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
