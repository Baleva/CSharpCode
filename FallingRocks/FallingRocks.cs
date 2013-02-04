using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    struct Entity
    {
        public int x;
        public int y;
        public string content;
        public ConsoleColor color;
    }

    // Print rocks or dwarf
    static void PrintObject(int x, int y, string str, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    // Build Rock
    static string BuildRock(int chance)
    {
        char[] rockTypes = new char[12] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
        string rockType = rockTypes[(chance % 12)].ToString();
        string rock = rockType;
        if (chance < 4)
        {
            rock = rockType + rockType + rockType;
        }
        else if (chance < 15)
        {
            rock = rockType + rockType;
        }
        return rock;
    }

    // Choose Color
    static ConsoleColor ChooseColor(int chance)
    {
        ConsoleColor color = ConsoleColor.White;
        switch (chance % 3)
        {
            case 0:
                color = ConsoleColor.Blue;
                break;
            case 1:
                color = ConsoleColor.Yellow;
                break;
            case 2:
                color = ConsoleColor.DarkCyan;
                break;
            default:
                color = ConsoleColor.White;
                break;
        }
        return color;
    }

    static void Main()
    {
        int playfieldWidth = 40;
        int livesCount = 5;
        int scoreCount = 0;
        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 60;
        Entity dwarf = new Entity();
        dwarf.x = 18;
        dwarf.y = 19;
        dwarf.color = ConsoleColor.White;
        dwarf.content = "(0)";
        Random randomGenerator = new Random();
        List<Entity> rocks = new List<Entity>();
        while (true)
        {
            bool hitted = false;
            int firstChance = randomGenerator.Next(0, 100);
            // Choose number of rocks in line
            int rocksInLine = firstChance / 20;
            // Move rocks
            List<Entity> newRocks = new List<Entity>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Entity oldRock = rocks[i];
                Entity newRock = new Entity();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.content = oldRock.content;
                newRock.color = oldRock.color;
                if (newRock.y < Console.WindowHeight)
                {
                    newRocks.Add(newRock);
                }
                else
                {
                    scoreCount += oldRock.content.Length; 
                }
                if (dwarf.x > (newRock.x - 3) && dwarf.x < (newRock.x + newRock.content.Length) && newRock.y == 19)
                {
                    hitted = true;
                }
            }
            rocks = newRocks;

            // Generate rocks in top line
            for (int i = 0; i < rocksInLine; i++)
            {
                int secondChance = randomGenerator.Next(0, playfieldWidth);
                Entity newRock = new Entity();
                newRock.content = BuildRock(secondChance);
                newRock.x = secondChance - newRock.content.Length + 1;
                if (newRock.x < 0)
                {
                    newRock.x = 0;
                }
                newRock.y = 0;
                newRock.color = ChooseColor(secondChance);
                rocks.Add(newRock);
            }
            // Take user input - move dwarf right or left
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x >= 1)
                    {
                        dwarf.x = dwarf.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x + 3 < playfieldWidth)
                    {
                        dwarf.x = dwarf.x + 1;
                    }
                }
            }
            // Print current content
            Console.Clear();
            foreach (Entity rock in rocks)
            {
                PrintObject(rock.x, rock.y, rock.content, rock.color);
            }
            PrintObject(42, 5, "SCORE: " + scoreCount, ConsoleColor.DarkGreen);
            PrintObject(42, 7, "LIVES: " + livesCount, ConsoleColor.DarkGreen);
            if (hitted)
            {
                for (int i = 0; i < 3; i++)
                {
                    PrintObject(dwarf.x, dwarf.y, "BOOM", ConsoleColor.Red);
                    Thread.Sleep(300);
                    PrintObject(dwarf.x, dwarf.y, "BOOM", ConsoleColor.White);
                    Thread.Sleep(300);
                }
                livesCount--;
                rocks.Clear();
                Console.Clear();
            }
            else
            {
                PrintObject(dwarf.x, dwarf.y, dwarf.content, dwarf.color);
            }
            if (livesCount < 1)
            {
                PrintObject(20, 5, "GAME OVER!", ConsoleColor.DarkGreen);
                PrintObject(20, 7, "YOUR SCORE: " + scoreCount, ConsoleColor.DarkGreen);
                PrintObject(20, 9, "Press [enter] to exit", ConsoleColor.DarkGreen);
                Console.ReadLine();
                Environment.Exit(0);
            }
            Thread.Sleep(150);
        }
    }
}
