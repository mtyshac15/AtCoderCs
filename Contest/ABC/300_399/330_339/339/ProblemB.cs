﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderCs.Contest.ABC339
{
    public class ProblemB
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var H = input[0];
            var W = input[1];
            var N = input[2];

            var grid = new char[H, W];
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    grid[i, j] = '.';
                }
            }

            var currentI = 0;
            var currentJ = 0;

            var directionI = -1;
            var directionJ = 0;

            for (var i = 0; i < N; i++)
            {
                var tempI = directionI;
                var tempJ = directionJ;

                if (grid[currentI, currentJ] == '.')
                {
                    grid[currentI, currentJ] = '#';

                    //[0. 1]
                    //[-1 0]

                    directionI = tempJ;
                    directionJ = -tempI;
                }
                else
                {
                    grid[currentI, currentJ] = '.';

                    //[0. -1]
                    //[1 0]

                    directionI = -tempJ;
                    directionJ = tempI;
                }

                currentI += directionI + H;
                currentI %= H;
                currentJ += directionJ + W;
                currentJ %= W;
            }

            var strtBuilder = new StringBuilder();

            //行、列
            var row = grid.GetLength(0);
            var col = grid.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    strtBuilder.Append(grid[i, j]);
                }
                strtBuilder.AppendLine();
            }

            Console.WriteLine(strtBuilder.ToString());
        }
    }
}
