using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class CollectionsBenchmark
{
    [Params(1, 10, 100)]
    public int elementCount;

    private List<int> list;
    private LinkedList<int> linkedList;
    private HashSet<int> hashSet;
    private Dictionary<int, int> dictionary;
    private SortedList<int, int> sortedList;
    private Queue<int> queue;
    private Stack<int> stack;

    [GlobalSetup]
    public void Setup()
    {
        list = new List<int>();
        linkedList = new LinkedList<int>();
        hashSet = new HashSet<int>();
        dictionary = new Dictionary<int, int>();
        sortedList = new SortedList<int, int>();
        queue = new Queue<int>();
        stack = new Stack<int>();

        for (int i = 0; i < elementCount; i++)
        {
            list.Add(i);
            linkedList.AddLast(i);
            hashSet.Add(i);
            dictionary[i] = i;
            sortedList[i] = i;
            queue.Enqueue(i);
            stack.Push(i);
        }
    }

    // Adding elements

    [Benchmark]
    public void ListAdd()
    {
        for (int i = 0; i < elementCount; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void LinkedListAdd()
    {
        for (int i = 0; i < elementCount; i++)
        {
            linkedList.AddLast(i);
        }
    }

    [Benchmark]
    public void HashSetAdd()
    {
        for (int i = 0; i < elementCount; i++)
        {
            hashSet.Add(i);
        }
    }

    [Benchmark]
    public void DictionaryAdd()
    {
        for (int i = 0; i < elementCount; i++)
        {
            dictionary[i] = i;
        }
    }

    [Benchmark]
    public void SortedListAdd()
    {
        for (int i = 0; i < elementCount; i++)
        {
            sortedList[i] = i;
        }
    }

    [Benchmark]
    public void QueueEnqueue()
    {
        for (int i = 0; i < elementCount; i++)
        {
            queue.Enqueue(i);
        }
    }

    [Benchmark]
    public void StackPush()
    {
        for (int i = 0; i < elementCount; i++)
        {
            stack.Push(i);
        }
    }

    // Iterating through elements

    [Benchmark]
    public void ListIterate()
    {
        foreach (var item in list) { }
    }

    [Benchmark]
    public void LinkedListIterate()
    {
        foreach (var item in linkedList) { }
    }

    [Benchmark]
    public void HashSetIterate()
    {
        foreach (var item in hashSet) { }
    }

    [Benchmark]
    public void DictionaryIterate()
    {
        foreach (var item in dictionary) { }
    }

    [Benchmark]
    public void SortedListIterate()
    {
        foreach (var item in sortedList) { }
    }

    [Benchmark]
    public void QueueIterate()
    {
        foreach (var item in queue) { }
    }

    [Benchmark]
    public void StackIterate()
    {
        foreach (var item in stack) { }
    }

    // Accessing elements by index or key (where applicable)

    [Benchmark]
    public void ListAccess()
    {
        for (int i = 0; i < elementCount; i++)
        {
            var item = list[i];
        }
    }

    [Benchmark]
    public void DictionaryAccess()
    {
        for (int i = 0; i < elementCount; i++)
        {
            var item = dictionary[i];
        }
    }

    [Benchmark]
    public void SortedListAccess()
    {
        for (int i = 0; i < elementCount; i++)
        {
            var item = sortedList[i];
        }
    }

    // Removing elements

    [Benchmark]
    public void ListRemove()
    {
        for (int i = 0; i < elementCount; i++)
        {
            list.Remove(i);
        }
    }

    [Benchmark]
    public void LinkedListRemove()
    {
        for (int i = 0; i < elementCount; i++)
        {
            linkedList.Remove(i);
        }
    }

    [Benchmark]
    public void HashSetRemove()
    {
        for (int i = 0; i < elementCount; i++)
        {
            hashSet.Remove(i);
        }
    }

    [Benchmark]
    public void DictionaryRemove()
    {
        for (int i = 0; i < elementCount; i++)
        {
            dictionary.Remove(i);
        }
    }

    [Benchmark]
    public void SortedListRemove()
    {
        for (int i = 0; i < elementCount; i++)
        {
            sortedList.Remove(i);
        }
    }

    [Benchmark]
    public void QueueDequeue()
    {
        for (int i = 0; i < elementCount; i++)
        {
            queue.Dequeue();
        }
    }

    [Benchmark]
    public void StackPop()
    {
        for (int i = 0; i < elementCount; i++)
        {
            stack.Pop();
        }
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var summary = BenchmarkRunner.Run<CollectionsBenchmark>();
//     }
// }
