using BinarySearch;
using Common;
using SelectionSort;
using System;

namespace AlgorithmsAndDataStructures.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleUtils.SetForegroundColor(ConsoleColor.White);

            var menu = new ConsoleOptionsMenu<IApp>("Choose an App to be executed:");
            menu.AddOption(new BinarySearchApp());
            menu.AddOption(new SelectionSortApp());

            IApp? app;
            while (true)
            {
                app = menu.PickAnOption();

                if (app == null)
                    break;

                app.Run(cleanBefore: true, cleanAfter: true);
            }

            ConsoleUtils.JumpLine();
            ConsoleUtils.WriteLine("Thanks for using this app. See you :)", ConsoleColor.White);
        }
    }
}


