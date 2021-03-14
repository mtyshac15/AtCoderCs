using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC194
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var (A, B) = IOLibrary.ReadInt2();
            var milkSolids = A + B;
            var milkFat = B;
            if (milkSolids >= 15 && milkFat >= 8)
            {
                Console.WriteLine(1);
            }
            else if (milkSolids >= 10 && milkFat >= 3)
            {
                Console.WriteLine(2);
            }
            else if (milkSolids >= 3)
            {
                Console.WriteLine(3);
            }
            else
            {
                Console.WriteLine(4);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveE()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveF()
        {

        }
    }
}