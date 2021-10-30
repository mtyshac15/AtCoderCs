using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<T> : IEnumerable<T>
{
    private T[] buffer;
    private int capacity;
    private int firstIndex;
    private int lastIndex;

    public PriorityQueue(int capacity = 1024)
    {
        this.buffer = new T[capacity];
        this.capacity = capacity;
        this.firstIndex = 0;
    }


    public T this[int i]
    {
        get
        {
            var currentIndex = (this.firstIndex + i) % this.capacity;
            return this.buffer[currentIndex];
        }
        set
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentIndex = (this.firstIndex + i) % this.capacity;
            this.buffer[currentIndex] = value;
        }
    }

    public int Length { get; set; }

    public void PushBack()
    {

    }

    public void PushFront()
    {

    }

    public T PopBack()
    {
        return this[this.firstIndex];
    }

    public T PopFront()
    {
        return this[this.lastIndex];
    }



    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Length; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < this.Length; i++)
        {
            yield return this[i];
        }
    }
}