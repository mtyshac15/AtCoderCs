using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Template
{
    public static void Method()
    {

    }

    #region "Input"

    static void Input()
    {
        {
            var str = IOLibrary.ReadLine();
        }

        {
            var N = IOLibrary.ReadInt();
        }

        {
            var (N, M) = IOLibrary.ReadInt2();
        }

        {
            var (N, M, K) = IOLibrary.ReadInt3();
        }

        {
            var numLong = IOLibrary.ReadLong();
        }

        {
            var (N, M) = IOLibrary.ReadLong2();
        }

        {
            var (N, M, K) = IOLibrary.ReadLong3();
        }

        {
            var input = IOLibrary.ReadIntArray();
        }

        {
            var input = IOLibrary.ReadLongArray();
        }

        {
            var list = IOLibrary.ReadIntList();
        }

        {
            var list = IOLibrary.ReadLongList();
        }

        {
            var N = 1;
            var int2DArray = IOLibrary.ReadInt2DArray(N);

        }
        {
            var N = 1;
            var long2DArray = IOLibrary.ReadLong2DArray(N);
        }
    }

    #endregion

    #region "Output"

    static void Output()
    {

        {
            var ans = 0;
            Console.WriteLine(ans);
        }

        {
            Console.WriteLine(IOLibrary.YesOrNo(true));
            return;
        }

        {
            var ans = 0;
            Console.WriteLine(ans);
            return;
        }
    }

    #endregion

    #region "Loop"

    static void Loop()
    {
        {
            var N = 1;
            for (var i = 0; i < N; i++)
            {

            }
        }

        {
            var N = 1;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {

                }
            }
        }

        {
            var N = 1;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    for (var k = 0; k < N; k++)
                    {
                    }
                }
            }
        }
    }

    #endregion
}
