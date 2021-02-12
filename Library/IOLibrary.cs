﻿using System;
using System.Collections.Generic;
using System.Linq;

public static class IOLibrary
{
    #region "Input"

    private static Func<string> ReadMethod { get; set; } = Console.ReadLine;

    public static void SetReadLineMethod(Func<string> readLine)
    {
        IOLibrary.ReadMethod = readLine;
    }

    #region "string"

    public static string ReadLine()
    {
        return IOLibrary.ReadMethod();
    }

    public static string[] ReadStringArray()
    {
        return IOLibrary.ReadLine().Trim().Split(' ');
    }

    public static string[] ReadStringArray(int row)
    {
        var array = new string[row];
        for (var i = 0; i < row; i++)
        {
            array[i] = IOLibrary.ReadLine();
        }
        return array;
    }

    public static string[,] ReadStringArray(int row, int col)
    {
        var array = new string[row, col];
        for (var i = 0; i < row; i++)
        {
            var line = IOLibrary.ReadLine();
            for (var j = 0; j < col; j++)
            {
                array[i, j] = line[j].ToString();
            }
        }
        return array;
    }

    public static Matrix GetMatrix(int rowCount, int colCount)
    {
        var matrix = new Matrix(rowCount, colCount);

        for(var row = 0;row<rowCount; row++)
        {
            var rows = IOLibrary.ReadLongArray();
            matrix.Init(row, rows);
        }

        return matrix;
    }

    #endregion

    #region "int"

    public static int ReadInt()
    {
        return int.Parse(IOLibrary.ReadLine());
    }

    public static (int, int) ReadInt2()
    {
        var inputs = IOLibrary.ReadIntArray();
        return (inputs[0], inputs[1]);
    }

    public static (int, int, int) ReadInt3()
    {
        var inputs = IOLibrary.ReadIntArray();
        return (inputs[0], inputs[1], inputs[2]);
    }

    public static (int, int, int, int) ReadInt4()
    {
        var inputs = IOLibrary.ReadIntArray();
        return (inputs[0], inputs[1], inputs[2], inputs[3]);
    }

    public static int[] ReadIntArray()
    {
        return IOLibrary.ReadStringArray()
                        .Select(item => int.Parse(item))
                        .ToArray();
    }

    public static int[] ReadIntArray(int row)
    {
        var array = new int[row];
        for (var i = 0; i < row; i++)
        {
            array[i] = IOLibrary.ReadInt();
        }
        return array;
    }

    public static int[][] ReadInt2DArray(int size)
    {
        var array = new int[size][];
        for (var i = 0; i < size; i++)
        {
            array[i] = IOLibrary.ReadIntArray();
        }
        return array;
    }

    public static int[,] ReadInt2DArray(int row, int col)
    {
        var array = new int[row, col];
        for (var i = 0; i < row; i++)
        {
            var line = IOLibrary.ReadIntArray();
            for (var j = 0; j < col; j++)
            {
                array[i, j] = line[j];
            }
        }
        return array;
    }

    #endregion

    #region "long"

    public static long ReadLong()
    {
        return long.Parse(IOLibrary.ReadLine());
    }

    public static (long, long) ReadLong2()
    {
        var inputs = IOLibrary.ReadLongArray();
        return (inputs[0], inputs[1]);
    }

    public static (long, long, long) ReadLong3()
    {
        var inputs = IOLibrary.ReadLongArray();
        return (inputs[0], inputs[1], inputs[2]);
    }

    public static (long, long, long, long) ReadLong4()
    {
        var inputs = IOLibrary.ReadLongArray();
        return (inputs[0], inputs[1], inputs[1], inputs[3]);
    }

    public static long[] ReadLongArray()
    {
        return IOLibrary.ReadStringArray()
                        .Select(item => long.Parse(item))
                        .ToArray();
    }

    public static long[] ReadLongArray(long row)
    {
        var array = new long[row];
        for (var i = 0; i < row; i++)
        {
            array[i] = IOLibrary.ReadLong();
        }
        return array;
    }

    public static long[][] ReadLong2DArray(long size)
    {
        var array = new long[size][];
        for (var i = 0; i < size; i++)
        {
            array[i] = IOLibrary.ReadLongArray();
        }
        return array;
    }

    public static long[,] ReadLong2DArray(long row, long col)
    {
        var array = new long[row, col];
        for (var i = 0; i < row; i++)
        {
            var line = IOLibrary.ReadLongArray();
            for (var j = 0; j < col; j++)
            {
                array[i, j] = line[j];
            }
        }
        return array;
    }

    #endregion

    public static ModInt[] ReadModIntArray(int mod)
    {
        ModInt.Init(mod);
        return IOLibrary.ReadStringArray()
                        .Select(item => (ModInt)int.Parse(item))
                        .ToArray();
    }

    #endregion

    #region "Output"

    public static void OutputList<T>(IEnumerable<T> line)
    {
        foreach (var item in line)
        {
            Console.WriteLine(item);
        }
    }

    public static void WriteYesOrNo(bool value)
    {
        Console.WriteLine(IOLibrary.ToYesOrNo(value));
    }

    public static string ToYesOrNo(bool value)
    {
        return value ? $"Yes" : $"No";
    }

    public static T DeepClone<T>(this T source)
    {
        using (var memoryStream = new System.IO.MemoryStream())
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            //シリアライズ
            binaryFormatter.Serialize(memoryStream, source);
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);

            //デシリアライズ
            var deserializedBinary = (T)binaryFormatter.Deserialize(memoryStream);
            return deserializedBinary;
        }
    }

    #endregion
}