using System;

class AngryBits
{
    static void Main()
    {
        int[,] field = new int[8, 16];
        int result = 0;
        for (int i = 0; i < 8; i++)
        {
            ushort number = ushort.Parse(Console.ReadLine());
            for (int j = 0; j < 16; j++)
            {
                field[i, j] = TakeBit(j, number);
            }
        }
        for (int j = 8; j < 16; j++)
        {
            int birdRow = -1;
            int birdCol = -1;
            int addToRow = -1;
            int flight = 0;
            int hit = 0;
            for (int i = 0; i < 8; i++)
            {
                if (field[i, j] == 1)
                {
                    birdRow = i;
                    birdCol = j;
                    field[i, j] = 0;
                    break;
                }
            }
            if (birdRow >= 0)
            {
                do
                {
                    flight++;
                    birdCol--;
                    if ((birdRow + addToRow < 0) || (birdRow + addToRow > 7))
                    {
                        addToRow *= -1;
                    }
                    birdRow += addToRow;
                    if ((birdCol < 8) && (field[birdRow, birdCol] == 1))
                    {
                        for (int k = birdRow - 1; k <= birdRow + 1; k++)
                        {
                            for (int l = birdCol - 1; l <= birdCol + 1; l++)
                            {
                                if ((k >= 0) && (k < 8) && (l >= 0) && (l < 8))
                                {
                                    if (field[k, l] == 1)
                                    {
                                        hit++;
                                        field[k, l] = 0;
                                    }
                                }
                            }
                        }
                        birdCol = -1;
                    }
                    if (birdRow == 7)
                    {
                        birdCol = -1;
                    }
                } while (birdCol > 0);
            }

            result += hit * flight;
        }
        int sum = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                sum += field[i,j];
            }
        }
        string win = "No";
        if (sum == 0)
        {
            win = "Yes";
        }
        Console.WriteLine("{0} {1}",result,win);
    }
    static int TakeBit(int position, int number)
    {
        int bit = ((1 << position) & number) >> position;
        return bit;
    }


}
