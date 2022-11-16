using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ConsoleUtils
    {
        private static ConsoleColor? _currentColor = null;

        public static void JumpLine(int lines = 1)
        {
            for (int i = 0; i < lines; i++)
            {
                WriteLine("");
            }
        }

        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            WriteLine(text, null, color);
        }

        public static void WriteLine(string text, object[]? args, ConsoleColor color = ConsoleColor.White)
        {
            SetForegroundColor(color);

            Console.WriteLine(text, args);
        }

        public static void Write(string text, ConsoleColor color = ConsoleColor.White)
        {
            Write(text, null, color);
        }

        public static void Write(string text, object[]? args, ConsoleColor color = ConsoleColor.White)
        {
            SetForegroundColor(color);

            Console.Write(text, args);
        }

        public static int ReadNumber()
        {
            var val = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && val.Length > 0)
                {
                    val = val.Substring(0, val.Length - 1);
                    Console.Write("\b \b");
                }
                else
                {
                    var typedChar = key.KeyChar.ToString();
                    if (int.TryParse(typedChar, out _))
                    {
                        val += typedChar;
                        Console.Write(typedChar);
                    }
                }

            } while (key.Key != ConsoleKey.Enter);

            JumpLine();

            var number = string.IsNullOrEmpty(val) ? 0 : int.Parse(val);

            return number;
        }

        public static void SetForegroundColor(ConsoleColor color)
        {
            if (_currentColor != color)
            {
                Console.ForegroundColor = color;
                _currentColor = color;
            }
        }
    }
}
