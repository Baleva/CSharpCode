using System;

class UKFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n/2; i++)
        {
            for (int j = 1; j < i; j++)
            {
                Console.Write('.');
            }
            Console.Write('\\');
            for (int j = i; j < n/2; j++)
            {
                Console.Write('.');
            }
            Console.Write('|');
            for (int j = i; j < n / 2; j++)
            {
                Console.Write('.');
            }
            Console.Write('/');
            for (int j = 1; j < i; j++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }
        for (int i = 1; i <= n/2; i++)
        {
            Console.Write('-');
        }
        Console.Write('*');
        for (int i = 1; i <= n / 2; i++)
        {
            Console.Write('-');
        }
        Console.WriteLine();
        for (int i = n/2; i >= 1; i--)
        {
            for (int j = 1; j < i; j++)
            {
                Console.Write('.');
            }
            Console.Write('/');
            for (int j = i; j < n / 2; j++)
            {
                Console.Write('.');
            }
            Console.Write('|');
            for (int j = i; j < n / 2; j++)
            {
                Console.Write('.');
            }
            Console.Write('\\');
            for (int j = 1; j < i; j++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }

    }
}
