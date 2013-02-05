using System;

class Program
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < 3; i++)
        {
            int count = CountNumbers(k);
            if (count == 1)
            {
                break;
            }
            int lastDigit = k % 10;
            k = k / 10;
            for (int j = 0; j < count-1; j++)
            {
                lastDigit *= 10;
            }
            k = lastDigit + k;
        }
        Console.WriteLine(k);
    }
    static int CountNumbers(int n)
    {
        int count = 0;
        do
        {
            n = n / 10;
            count++;
        } while (n> 0);
        return count;
    }
}
