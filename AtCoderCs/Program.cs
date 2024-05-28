using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderCs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"{1000} {2000}");

            var reader = new StringReader(strBuilder.ToString());
            var writer = new StringWriter();

            var problem = new AtCoderCs.Traing.MathematicsAlgorithm.Problem008.Problem(reader, writer);
            problem.Solve();
            Console.WriteLine(writer.ToString());
        }
    }
}
