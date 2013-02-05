using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Crossword
{
    static List<string> words = new List<string>();
    static int n;
    static bool solved = false;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < 2 * n; i++)
        {
            words.Add(Console.ReadLine());
        }
        words.Sort();
        StringBuilder sb = new StringBuilder();
        Variations(sb);
        if (!solved)
        {
            Console.WriteLine("NO SOLUTION!");
        }
    }

    static void Variations(StringBuilder sb)
    {
        if (solved)
        {
            return;
        }
        StringBuilder currentSb = new StringBuilder();
        currentSb.Append(sb.ToString());
        if (currentSb.Length < n*n)
        {
            currentSb.Append(words[0]);
            for (int i = 0; i < words.Count; i++)
            {
                currentSb.Remove(currentSb.Length - n, n);
                currentSb.Append(words[i]);
                Variations(currentSb);
            }
        }
        else
        {
            MakePrint(sb);
        }
    }

    static void MakePrint(StringBuilder sb)
    {
        //check columns
        bool areWords = true;
        for (int col = 0; col < n; col++)
        {
            string word = "";
            for (int row = 0; row < n; row++)
            {
                word += sb[row * n + col];
            }
            if (words.FindIndex(a=> a == word) < 0 )
            {
                areWords = false;
                break;
            }
            word = "";
        }
        if (areWords)
        {
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(sb.ToString(row*n,n));
            }
            solved = true;
        }
    }
}
