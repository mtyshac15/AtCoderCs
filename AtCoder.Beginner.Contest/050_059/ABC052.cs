using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC052
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var N = IOLibrary.ReadInt();
            var S = IOLibrary.ReadLine();

            var x = 0;
            var max = x;
            foreach (var str in S)
            {
                if (str == 'I')
                {
                    x++;
                }
                else if (str == 'D')
                {
                    x--;
                }
                max = Math.Max(x, max);
            }

            IOLibrary.WriteLine(max);
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

        #region 

        #endregion

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