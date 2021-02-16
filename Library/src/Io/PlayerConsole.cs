using System;
using static System.Console;

namespace Library.Io
{
    public class PlayerConsole : IConsole
    {
        public void Print(string message)
        {
            WriteLine(message);
        }

        public string GetString()
        {
            return ReadLine();
        }

        public int GetInt()
        {
            string input = ReadLine();
            int number;
            while (!int.TryParse(input, out number))
            {
                WriteLine("Please input a valid integer");
                input = ReadLine();
            }
            return number;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}