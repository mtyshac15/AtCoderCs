using AtCoder.Common;
using System;
using System.Linq;

namespace Training.ATC001
{
    public class Problem
    {
        private bool[][] field;

        private int[][] direction = new int[][]
        {
           new int[] { 0, -1 },
           new int[] { 1, 0 },
           new int[] { 0, 1 },
           new int[] { -1, 0 },
        };

        public void SolveA()
        {
            var (H, W) = IOLibrary.ReadInt2();
            var c = IOLibrary.ReadStringArray(H);

            this.field = new bool[H][];
            for (int i = 0; i < H; i++)
            {
                this.field[i] = new bool[W];
            }

            int startH = 0;
            int startW = 0;

            int goalH = 0;
            int goalW = 0;

            //開始地点を探索
            for (var h = 0; h < H; h++)
            {
                for (int w = 0; w < W; w++)
                {
                    if (c[h][w] == 's')
                    {
                        startH = h;
                        startW = w;
                    }
                    else if (c[h][w] == 'g')
                    {
                        goalH = h;
                        goalW= w;
                    }
                }
            }

            //深さ優先探索
            this.Serch(H, W, c, startH, startW);
            
            var can = this.field[goalH][goalW];
            IOLibrary.WriteYesOrNo(can);
        }

        private void Serch(int H, int W, string[] c, int h, int w)
        {
            //探索済み
            this.field[h][w] = true;

            if (c[h][w] == 'g')
            {
                return;
            }

            //壁の場合は、探索終了
            if (c[h][w] == '#')
            {
                return;
            }

            //各方向を探索
            foreach (var item in this.direction)
            {
                int nextH = h + item[0];
                int nextW = w + item[1];

                if (nextH >= 0 && nextH < H
                    && nextW >= 0 && nextW < W)
                {
                    if (!this.field[nextH][nextW])
                    {
                        //未探索の場合は、探索を行う
                        this.Serch(H, W, c, nextH, nextW);
                    }
                }
            }
        }

        public void SolveB()
        {

        }

        public void SolveC()
        {

        }
    }
}
