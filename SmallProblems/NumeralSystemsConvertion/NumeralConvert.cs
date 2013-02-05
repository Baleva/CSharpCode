using System;

class NumeralConvert
{
    static void Main()
    {
        int s = 16;
        int d = 8;
        string number = "AC1";
        int decimalNumber = ToDecimal(number, s);
        string baseNumber = ToBase(decimalNumber, d);
        Console.WriteLine("Number in {1} base system - {0}", number,s);
        Console.WriteLine("Number in decimal base system - {0}", decimalNumber);
        Console.WriteLine("Number in {1} base system - {0}", baseNumber,d);
    }

    static string ToBase(int number, int systemBase)
    {
        string result = "";
        while (number > 0)
        {
            result = TakeBase(number % systemBase) + result;
            number /= systemBase;
        }
        return result;
    }

    static string TakeBase(int number)
    {
        string text = "";
        switch (number)
        {
            case 10:
                text = "A";
                break;
            case 11:
                text = "B";
                break;
            case 12:
                text = "C";
                break;
            case 13:
                text = "D";
                break;
            case 14:
                text = "E";
                break;
            case 15:
                text = "F";
                break;
            default:
                text = number.ToString();
                break;
        }
        return text;
    }

    static int ToDecimal(string text, int systemBase)
    {
        int result = 0;
        int multiplier = 1;
        for (int i = text.Length - 1; i >= 0; i--)
        {
            result += TakeDecimal(text[i]) * multiplier;
            multiplier *= systemBase;
        }
        return result;
    }

    static int TakeDecimal(char symbol)
    {
        int number = 0;
        switch (symbol)
        {
            case 'A':
                number = 10;
                break;
            case 'B':
                number = 11;
                break;
            case 'C':
                number = 12;
                break;
            case 'D':
                number = 13;
                break;
            case 'E':
                number = 14;
                break;
            case 'F':
                number = 15;
                break;
            default:
                number = int.Parse(symbol + "");
                break;
        }
        return number;
    }

}
