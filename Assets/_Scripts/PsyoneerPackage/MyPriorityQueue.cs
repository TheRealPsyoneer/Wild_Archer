using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPriorityQueue<T>
{
    List<(T value, int priority)> queue;
    public int Count => queue.Count;

    public MyPriorityQueue()
    {
        queue = new();
    }

    public void Enqueue(T value, int priority)
    {
        queue.Add((value, priority));

        int childIndex = queue.Count - 1;

        while (childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;
            if (queue[childIndex].priority < queue[parentIndex].priority)
            {
                SwapNode(childIndex, parentIndex);

                childIndex = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    public T Peek()
    {
        if (queue.Count == 0) 
        {
            throw new InvalidOperationException("pq empty");
        }

        return queue[0].value;
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("pq empty");
        }

        T dequeued = queue[0].value;

        SwapNode(0, queue.Count - 1);
        queue.RemoveAt(queue.Count - 1);

        int parentIndex = 0;

        while (parentIndex < queue.Count - 1)
        {
            int childIndex1 = parentIndex * 2 + 1;
            int childIndex2 = parentIndex * 2 + 2;

            if (childIndex1 > queue.Count - 1) break;

            if (childIndex2 > queue.Count - 1)
            {
                if (queue[parentIndex].priority > queue[childIndex1].priority)
                {
                    SwapNode(parentIndex, childIndex1);
                }
                break;
            }

            int comparingChildIndex = queue[childIndex1].priority < queue[childIndex2].priority ? childIndex1 : childIndex2;

            if (queue[parentIndex].priority > queue[comparingChildIndex].priority)
            {
                SwapNode(parentIndex, comparingChildIndex);

                parentIndex = comparingChildIndex;
            }
        }

        return dequeued;
    }

    private void SwapNode(int index1, int index2)
    {
        var temp = queue[index1];
        queue[index1] = queue[index2];
        queue[index2] = temp;
    }
}
