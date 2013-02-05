using System;
using System.Collections.Generic;

class MergeSort
{
    static void Main()
    {
        // Input part, array can be input throw console
        List<int> array = new List<int>();
        array.Add(101);
        array.Add(5);
        array.Add(8);
        array.Add(10);
        array.Add(51);
        array.Add(1);
        array.Add(8);
        array.Add(4);

        // MakeSort is recursive method, it use merge sort
        List<int> sortedArray = MakeSort(array);

        // Show result in console
        foreach (int item in sortedArray)
        {
            Console.WriteLine(item);
        }

    }
    static List<int> MakeSort(List<int> array)
    {
        List<int> firstHalf = new List<int>();
        List<int> secondHalf = new List<int>();
        List<int> merge = new List<int>();
        if (array.Count > 1)
        {
            foreach (int element in array)
            {
                if (firstHalf.Count < array.Count / 2)
                {
                    firstHalf.Add(element);
                }
                else
                {
                    secondHalf.Add(element);
                }
            }
            List<int> firstSorted = MakeSort(firstHalf);
            List<int> secondSorted = MakeSort(secondHalf);
            merge = MergeLists(firstSorted, secondSorted);
        }
        else
        {
            merge.Add(array[0]);
        }
        return merge;
    }
    static List<int> MergeLists(List<int> first, List<int> second)
    {
        List<int> combine = new List<int>();
        while ((first.Count >0) && (second.Count > 0))
        {
            if (first[0] < second[0])
            {
                combine.Add(first[0]);
                first.RemoveAt(0);
            }
            else
            {
                combine.Add(second[0]);
                second.RemoveAt(0);
            }
        }
        foreach (int item in first)
        {
            combine.Add(item);
        }
        foreach (int item in second)
        {
            combine.Add(item);
        }
        return combine;
    }
}
