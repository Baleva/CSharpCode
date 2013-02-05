using System;
using System.Collections.Generic;
using System.Linq;

class PrintVariations
{
    static int k;
    static int[] numbers;
    static void Main()
    {
        int n;
        List<int> set = new List<int>();
        Console.Write("N=");
        n = int.Parse(Console.ReadLine());        
        Console.Write("K=");
        k = int.Parse(Console.ReadLine());
        numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = i + 1;
        }
        MakePrint(set);
    }
    static void MakePrint(List<int> set)
    {
        List<int> currentSet = set.ToList();
        if (currentSet.Count < k)
        {
            currentSet.Add(numbers[0]);
            for (int i = 0; i < numbers.Length; i++)
            {
                currentSet[currentSet.Count - 1] = numbers[i];
                MakePrint(currentSet);
            }
        }
        else
        {
            for (int i = 0; i < set.Count; i++)
            {
                Console.Write(set[i]);
                if (i <set.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
}
