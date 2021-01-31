using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AGC
{
    public static void ErasingVertices()
    {
        var N = IOLibrary.ReadInt();

        var vertices = new string[N];

        for (var index = 0; index < N; index++)
        {
            vertices[index] = IOLibrary.ReadLine();
        }

        var countSum = 0;

        for (var startIndex = 0; startIndex < N; startIndex++)
        {
            var count = 0;

            var vertexIndexList = new List<int>();
            for (var index = 0; index < N; index++)
            {
                vertexIndexList.Add(index);
            }

            var currentVertexIndex = startIndex;
            var endIndex = (startIndex - 1 + N) % N;
            while (currentVertexIndex != endIndex)
            {
                if (!vertexIndexList.Any())
                {
                    break;
                }

                var vertexIndexQueue = new Queue<int>();
                vertexIndexQueue.Enqueue(currentVertexIndex);

                while (vertexIndexQueue.Any())
                {
                    var vertexIndex = vertexIndexQueue.Dequeue();
                    if (vertexIndexList.Contains(vertexIndex))
                    {
                        //頂点を削除
                        vertexIndexList.Remove(vertexIndex);

                        var vertex = vertices[vertexIndex];

                        //1の個数を数える
                        for (var index = 0; index < N; index++)
                        {
                            if (vertex[index] == '1')
                            {
                                vertexIndexQueue.Enqueue(index);
                            }
                        }
                    }
                }

                count++;

                currentVertexIndex++;
                currentVertexIndex %= N;
            }

            countSum += count;
        }

        var average = (double)countSum / N;
        Console.WriteLine(average);
    }
}
