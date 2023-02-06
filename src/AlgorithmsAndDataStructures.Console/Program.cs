using BinarySearch;
using Common;
using SelectionSort;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.ConsoleApp
{
    public class Program
    {
        private static ConsoleColor _currentColor;

        public static void Main(string[] args)
        {
            ConsoleUtils.SetForegroundColor(ConsoleColor.White);

            var apps = new List<IApp>();
            apps.Add(new BinarySearchApp());
            apps.Add(new SelectionSortApp());

            var menu = new ConsoleOptionsMenu<IApp>("Choose an App to be executed:");
            menu.AddOptions(apps);

            IApp? app;
            while (true)
            {
                app = menu.PickAnOption(cleanAfter: true);

                if (app == null)
                    break;

                app.Run();
            }

            ConsoleUtils.JumpLine();
            ConsoleUtils.WriteLine("Thanks for using this app. See you :)", ConsoleColor.White);
        }
    }
}


