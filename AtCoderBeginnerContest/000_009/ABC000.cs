using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC035
{
    public class Program
    {
        #region 

        public static void BFS()
        {
            var (R, C) = IOLibrary.ReadInt2();
            var (sx, sy) = IOLibrary.ReadInt2();
            var (gx, gy) = IOLibrary.ReadInt2();
            var grid = IOLibrary.ReadStringArray(R, C);

            var countField = new int[R, C];

            var start = new Cell(sx - 1, sy - 1);
            var goal = new Cell(gx - 1, gy - 1);

            var searchedSet = new HashSet<Cell>();
            var queue = new Queue<Cell>();

            countField[start.Row, start.Column] = 0;
            queue.Enqueue(start);
            searchedSet.Add(start);

            var dr = new int[] { 0, 1, 0, -1 };
            var dc = new int[] { 1, 0, -1, 0 };

            while (queue.Any())
            {
                var currentCell = queue.Dequeue();
                if (currentCell == goal)
                {
                    break;
                }

                var step = countField[currentCell.Row, currentCell.Column];

                for (var i = 0; i < 4; i++)
                {
                    var nextRow = currentCell.Row + dr[i];
                    var nextColumn = currentCell.Column + dc[i];
                    if (nextRow >= 0 && nextRow < R
                        && nextColumn >= 0 && nextColumn < C)
                    {
                        var nextCell = new Cell(nextRow, nextColumn);
                        var value = grid[nextCell.Row, nextCell.Column];
                        if (value == "." && !searchedSet.Contains(nextCell))
                        {
                            countField[nextCell.Row, nextCell.Column] = step + 1;
                            queue.Enqueue(nextCell);
                            searchedSet.Add(nextCell);
                        }
                    }
                }
            }

            var minStep = countField[goal.Row, goal.Column];
            IOLibrary.WriteLine(minStep);
        }

        #endregion
    }
}