using System;
using System.Collections.Generic;

namespace Checkpoint_2
{
    class Program
    {
        //Fields used by the GetColor method only
        static ConsoleColor[] colorArray = new ConsoleColor[] {
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.Magenta,
            ConsoleColor.Cyan,
        };
        static int index = 0;
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Enter some data in the format A0-A0-A0: ");
            Console.WriteLine("A for ASCENDING, B for DESCENDING and the number for the base of the triangle: \n");
            Console.Write("Input: ");
            //Input from the user
            string input = Console.ReadLine();
            Console.WriteLine();
            List<Triangle> triangleList = ValidateInput(input);
            foreach (Triangle triangle in triangleList)
            {
                //Print triangles next to eachother in different colors which makes them easier to distinguish.
                Console.ForegroundColor = GetColor();
                if (triangle.MyPoint == Point.DESCENDING)
                {
                    DrawDescendingTriangle(triangle.MySize);
                }
                if (triangle.MyPoint == Point.ASCENDING)
                {
                    DrawAscendingTriangle(triangle.MySize);
                }
                Console.ResetColor();
            }
            //Restart
            Console.Write("\nPress RETURN to restart: ");
            Console.ReadLine();
            Main();
        }
        //Large to small
        //***
        //**
        //*
        static void DrawDescendingTriangle(int triangleBase)
        {
            for (int y = 0; y < triangleBase; y++)
            {
                int rowAmount = triangleBase - y;
                for (int x = rowAmount; x > 0; x--)
                {
                    Console.Write(" * ");
                }
                Console.WriteLine();
            }
        }
        //Small to large
        //*
        //**
        //***
        static void DrawAscendingTriangle(int triangleBase)
        {
            for (int y = 0; y < triangleBase; y++)
            {
                int rowAmount = y + 1;
                for (int x = 0; x < rowAmount; x++)
                {
                    Console.Write(" * ");
                }
                Console.WriteLine();
            }
        }
        //Check that the input meets the requirements of the instructions in the checkpoint
        static List<Triangle> ValidateInput(string input)
        {
            List<Triangle> triangleList = new List<Triangle>();
            //Split the string at dash signs
            string[] stringArray = input.Split("-");
            for (int i = 0; i < stringArray.Length; i++)
            {
                string s = stringArray[i].ToUpper();
                //Second to last characters in the string
                string subString = s.Substring(1, s.Length - 1);

                bool charBool = false;
                bool intBool = Int32.TryParse(subString, out int result);
                //char
                //The first character in the string should be the letter 'A' or 'B'.
                if (s[0] == 'A' || s[0] == 'B')
                {
                    charBool = true;
                }
                else
                {
                    PrintColoredMessage($"Char {s[0]} should be 'A' or 'B' !", ConsoleColor.Red);
                }
                //int
                //The characters after the first one should be an int
                if (intBool == false)
                {
                    PrintColoredMessage($"Couldn't convert '{subString}' to an integer!", ConsoleColor.Red);
                }
                //finally
                //If both requirements are met add it to the list
                if (charBool == true && intBool == true)
                {
                    triangleList.Add(new Triangle(result, s[0]));
                }
            }
            return triangleList;
        }
        static void PrintColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        //Get a color froma list of colors then increment the list
        static ConsoleColor GetColor()
        {
            ConsoleColor color = ConsoleColor.Black;

            color = colorArray[index];

            index++;
            if (index >= colorArray.Length)
                index = 0;

            return color;
        }
    }
}
