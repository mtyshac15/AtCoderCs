using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AtCoderCs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var problem = new AtCoderCs.Contest.ABC330.ProblemC();
            var a = problem.Calc(28);
            Console.WriteLine(a);
        }
    }
}
