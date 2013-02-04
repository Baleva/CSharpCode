using System;

class Poker
{
    static void Main()
    {
        string result;
        int[] cards = new int[5];
        for (int i = 0; i < 5; i++)
        {
            cards[i] = StringToNumber(Console.ReadLine());
        }
        Array.Sort(cards);
        bool isStraight = false;
        if (cards[0] == cards[4])
        {
            result = "Impossible";
        }
        else if ((cards[0] == cards[3]) || (cards[1] == cards[4]))
        {
            result = "Four of a Kind";
        }
        else if (((cards[0] == cards[2]) && (cards[3] == cards[4])) ||
            ((cards[0] == cards[1]) && (cards[2] == cards[4])))
        {
            result = "Full House";
        }

        else if (IsStraight(cards))
        {
            result = "Straight";
        }
        else if ((cards[0] == cards[2]) || (cards[1] == cards[3]) || (cards[2] == cards[4]))
        {
            result = "Three of a Kind";
        }
        else if (((cards[0] == cards[1]) && (cards[2] == cards[3])) ||
            ((cards[0] == cards[1]) && (cards[3] == cards[4])) ||
            ((cards[1] == cards[2]) && (cards[3] == cards[4])))
        {
            result = "Two Pairs";
        }
        else if ((cards[0] == cards[1]) || (cards[1] == cards[2]) || (cards[2] == cards[3]) ||
            (cards[3] == cards[4]))
        {
            result = "One Pair";
        }
        else
        {
            result = "Nothing";
        }
        Console.WriteLine(result);
    }




    static bool IsStraight(int[] card)
    {
        int[] current = card;
        bool isStraight = true;
        for (int i = 1; i < current.Length; i++)
        {

            if ((current[i] != current[i - 1] + 1) && (current[i] != current[i - 1] + 9))
            {
                isStraight = false;
                break;
            }
        }

        return isStraight;
    }

    static int StringToNumber(string text)
    {
        int number = 0;
        switch (text)
        {
            case "J":
                number = 11;
                break;
            case "Q":
                number = 12;
                break;
            case "K":
                number = 13;
                break;
            case "A":
                number = 14;
                break;
            default:
                number = int.Parse(text);
                break;
        }
        return number;
    }
}
