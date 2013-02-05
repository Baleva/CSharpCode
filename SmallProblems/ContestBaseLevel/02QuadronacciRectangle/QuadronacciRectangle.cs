using System;

class QuadronacciRectangle
{
    static void Main()
    {
        long[] q = new long[4];
        for (int i = 0; i < 4; i++)
        {
            q[i] = long.Parse(Console.ReadLine());
        }
        int r = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        long[] cr = new long[c*r];
        for (int i = 0; i < 4; i++)
        {
            cr[i] = q[i];
        }
        for (int i = 4; i < c*r; i++)
        {
            cr[i] = cr[i - 1] + cr[i - 2] + cr[i - 3] + cr[i - 4];
        }
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                Console.Write(cr[i*c+j]);
                if (j < c-1)
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}
