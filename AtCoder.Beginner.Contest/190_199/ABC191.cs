using AtCoder.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC191
{
    public class Problem : ProblemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override void SolveA()
        {
            var (V, T, S, D) = IOLibrary.ReadInt4();

            var start = V * T;
            var end = V * S;
            if (D < start || end < D)
            {
                IOLibrary.WriteYesOrNo(true);
            }
            else
            {
                IOLibrary.WriteYesOrNo(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveB()
        {
            var (N, X) = IOLibrary.ReadLong2();
            var A = IOLibrary.ReadLongArray();

            foreach (var a in A)
            {
                if (a != X)
                {
                    Console.Write(a + " ");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SolveC()
        {
            var (H, W) = IOLibrary.ReadInt2();
            var S = IOLibrary.ReadStringArray(H, W);

            var brack = "#";
            var white = ".";

            var ans = 0;
            for (var h = 0; h < H; h++)
            {
                for (var w = 0; w < W; w++)
                {
                    if (S[h, w] == brack)
                    {
                        //辺、または辺の一部かどうか判定

                        //左
                        if (S[h, w - 1] == white)
                        {
                            if (S[h - 1, w] == white)
                            {
                                ans++;
                            }
                            else if (S[h - 1, w - 1] == brack)
                            {
                                ans++;
                            }
                        }

                        //上
                        if (S[h - 1, w] == white)
                        {
                            if (S[h, w - 1] == white)
                            {
                                ans++;
                            }
                            else if (S[h - 1, w - 1] == brack)
                            {
                                ans++;
                            }
                        }

                        //右
                        if (S[h, w + 1] == white)
                        {
                            if (S[h - 1, w] == white)
                            {
                                ans++;
                            }
                            else if (S[h - 1, w + 1] == brack)
                            {
                                ans++;
                            }
                        }

                        //下
                        if (S[h + 1, w] == white)
                        {
                            if (S[h, w - 1] == white)
                            {
                                ans++;
                            }
                            else if (S[h + 1, w - 1] == brack)
                            {
                                ans++;
                            }
                        }
                    }
                }
            }

            IOLibrary.WriteLine(ans);
        }

        #region "old"

        public static void DigitalGraffitiOld()
        {
            var (H, W) = IOLibrary.ReadInt2();
            var S = IOLibrary.ReadStringArray(H, W);

            var unexploredCellStack = new Stack<int[]>();
            var whiteCountArray = new int[H, W];

            for (var h = 0; h < H; h++)
            {
                for (var w = 0; w < W; w++)
                {
                    whiteCountArray[h, w] = -1;
                    if (S[h, w] == "#")
                    {
                        if (!unexploredCellStack.Any())
                        {
                            unexploredCellStack.Push(new int[] { h, w });
                        }
                    }
                }
            }

            var count = Problem.SearchGrid(S, unexploredCellStack, 0, whiteCountArray);
            IOLibrary.WriteLine(count);
        }

        public static int SearchGrid(string[,] field, Stack<int[]> unexploredcellStack, int edgeCount, int[,] whiteCountArray)
        {
            if (!unexploredcellStack.Any())
            {
                return edgeCount;
            }

            var dh = new int[] { 0, 1, 0, -1 };
            var dw = new int[] { 1, 0, -1, 0 };

            var currentCell = unexploredcellStack.Pop();
            var currentH = currentCell[0];
            var currentW = currentCell[1];

            var whiteCount = Problem.RecordCell(field, unexploredcellStack, currentCell, whiteCountArray);
            if (whiteCount == 4)
            {
                return whiteCount;
            }
            else if (whiteCount == 3)
            {
                edgeCount += whiteCount;

                var h = currentH;
                var w = currentW;

                var directionIndex = 0;
                for (var i = 0; i < 4; i++)
                {
                    var nextH = h + dh[i];
                    var nextW = w + dw[i];

                    var cell = field[nextH, nextW];
                    if (cell == "#")
                    {
                        directionIndex = i;
                    }
                }

                //未探索のマスか、隣接する白のマスの数が3マスになるまで探索
                while (true)
                {
                    h += dh[directionIndex];
                    w += dw[directionIndex];

                    if (field[h, w] != "#")
                    {
                        break;
                    }

                    var nextWhiteCount = whiteCountArray[h, w];

                    if (nextWhiteCount == -1
                        || nextWhiteCount == 0)
                    {
                        break;
                    }

                    if (whiteCountArray[h + dh[directionIndex], w + dw[directionIndex]] == 3)
                    {
                        edgeCount -= nextWhiteCount;
                        break;
                    }
                }

                return Problem.SearchGrid(field, unexploredcellStack, edgeCount, whiteCountArray);
            }
            else if (whiteCount == 2)
            {
                var h = currentH;
                var w = currentW;

                var direction = "";

                //同じ方向にある場合は辺の一部
                if (field[h - 1, w] == "#"
                    && field[h + 1, w] == "#")
                {
                    var countUpper = Problem.RecordCell(field, unexploredcellStack, new int[] { h - 1, w }, whiteCountArray);
                    var countLower = Problem.RecordCell(field, unexploredcellStack, new int[] { h + 1, w }, whiteCountArray);

                    if (countUpper == 1 && countLower == 1)
                    {
                        edgeCount += 2;
                    }

                    direction = "h";
                }
                else if (field[h, w - 1] == "#"
                     && field[h, w + 1] == "#")
                {
                    var countLeft = Problem.RecordCell(field, unexploredcellStack, new int[] { h, w - 1 }, whiteCountArray);
                    var countRight = Problem.RecordCell(field, unexploredcellStack, new int[] { h, w + 1 }, whiteCountArray);

                    if (countLeft == 1 && countRight == 1)
                    {
                        edgeCount += 2;
                    }

                    direction = "w";
                }

                //隣接するマスが探索済みの場合は、一辺減らす
                if (string.IsNullOrWhiteSpace(direction))
                {
                    edgeCount += 2;

                    for (var i = 0; i < 4; i++)
                    {
                        var distance = 0;
                        while (true)
                        {
                            distance++;

                            var nextH = h + dh[i] * distance;
                            var nextW = w + dw[i] * distance;

                            if (field[nextH, nextW] != "#")
                            {
                                break;
                            }

                            var nextWhitCount = whiteCountArray[nextH, nextW];
                            if (nextWhitCount == 0)
                            {
                                break;
                            }

                            if (nextWhitCount == 2)
                            {
                                edgeCount--;
                                break;
                            }
                        }
                    }
                }

                return Problem.SearchGrid(field, unexploredcellStack, edgeCount, whiteCountArray);
            }

            return Problem.SearchGrid(field, unexploredcellStack, edgeCount, whiteCountArray);
        }

        public static int RecordCell(string[,] field, Stack<int[]> unexploredcellStack, int[] cell, int[,] whiteCountArray)
        {
            //4方向を探索
            var dh = new int[] { 0, 1, 0, -1 };
            var dw = new int[] { 1, 0, -1, 0 };

            var whiteCount = 4;

            for (var i = 0; i < 4; i++)
            {
                var nextH = cell[0] + dh[i];
                var nextW = cell[1] + dw[i];

                if (field[nextH, nextW] == "#")
                {
                    whiteCount--;
                    var nextCell = new int[] { nextH, nextW };
                    if (whiteCountArray[nextH, nextW] == -1 && unexploredcellStack.All(x => x[0] != nextCell[0] || x[1] != nextCell[1]))
                    {
                        unexploredcellStack.Push(nextCell);
                    }
                }
            }

            whiteCountArray[cell[0], cell[1]] = whiteCount;
            return whiteCount;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public override void SolveD()
        {
            var multiple = 10000;
            var input = IOLibrary.ReadStringArray()
                                 .Select(item => (long)(decimal.Parse(item) * multiple))
                                 .ToArray();

            var X = input[0];
            var Y = input[1];
            var R = input[2];

            var count = 0L;

            var maxR = 100000L;

            for (var y = -2 * maxR; y <= 2 * maxR; y++)
            {
                var tmpY = y * multiple;

                var dy = Math.Abs(Y - tmpY);

                if (dy <= R)
                {
                    var x2 = R * R - dy * dy;

                    Func<long, bool> isOk = (x) =>
                    {
                        var dx2 = (X - x) * (X - x);
                        return dx2 <= x2;
                    };

                    var minRange = -2 * maxR * multiple;
                    var maxRange = 2 * maxR * multiple;

                    var left = MathLibrary.BinarySearch(X, minRange - 1, isOk);
                    var right = MathLibrary.BinarySearch(X, maxRange + 1, isOk);

                    //10^4の倍数の個数
                    var countL = MathLibrary.Ceiling(left, multiple) / multiple;
                    var countR = MathLibrary.Floor(right, multiple) / multiple;

                    if (countL <= countR)
                    {
                        count += countR - countL + 1;
                    }
                }
            }

            IOLibrary.WriteLine(count);
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