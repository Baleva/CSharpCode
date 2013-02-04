using System;
using System.Collections.Generic;

class SubsetSum
{
    static List<long> subset = new List<long>();
    static void Main()
    {
        Console.Write("S=");
        long s = long.Parse(Console.ReadLine());
        Console.Write("N=");
        int n = int.Parse(Console.ReadLine());
        long[] number = new long[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("N[{0}]=",i);
            number[i] = long.Parse(Console.ReadLine());
        }
        bool noSubset = true;
        for (int i = 1; i < Math.Pow(2,n); i++)
        {
            if (s == CalculateSum(i,number))
            {
                for (int j = 0; j < subset.Count; j++)
                {
                    Console.Write(subset[j]);
                    if (j != subset.Count -1)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write("=");
                    }
                }
                Console.WriteLine(s);
                noSubset = false;
                break;
            }
            subset.Clear();
        }
        if (noSubset)
        {
            Console.WriteLine("There is no such subset");
        }
    }
    static long CalculateSum(int subSet, long[] number)
    {
        long sum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            int bit = (subSet & (1<<i)) >> i;
            sum += number[i]*bit;
            if (bit == 1)
            {
                subset.Add(number[i]);
            }
        }
        return sum;
    }
}
