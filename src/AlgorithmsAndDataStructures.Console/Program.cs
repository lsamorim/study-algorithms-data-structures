using BinarySearch;
using Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.ConsoleApp
{
    public class Program
    {
        private static ConsoleColor _currentColor;

        public static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information

            ConsoleUtils.SetForegroundColor(ConsoleColor.White);

            var apps = new List<IApp>();
            apps.Add(new BinarySearchApp());

            var menu = new ConsoleOptionsMenu<IApp>("Choose an App to be executed:");
            menu.AddOptions(apps);

            Option<IApp>? option;
            do
            {
                option = menu.PickAnOption(cleanAfter: true);

                if (option != null)
                {
                    option.Result.Run();
                }

            } while (option != null);

            //var currentAppId = 0;
            //do
            //{
            //    ConsoleUtils.WriteLine("Choose an App to be executed:", ConsoleColor.Cyan);
            //    ConsoleUtils.JumpLine();

            //    foreach (var option in apps)
            //    {
            //        var app = option.Value;
            //        ConsoleUtils.WriteLine($"{option.Key} - {app.Name}: {app.Description}");
            //    }
            //    ConsoleUtils.WriteLine("0 - Exit");

            //    ConsoleUtils.Write("Please type: ");
            //    currentAppId = ConsoleUtils.ReadNumber();

            //    if (currentAppId != 0)
            //    {
            //        if (apps.TryGetValue(currentAppId, out var app))
            //        {
            //            Console.Clear();
            //            app.Run();
            //        }
            //        else
            //        {
            //            ConsoleUtils.JumpLine();
            //            ConsoleUtils.WriteLine($"Invalid App Id: {currentAppId} - Please choose a valid option.", ConsoleColor.Red);
            //            Console.ReadKey();
            //        }

            //        Console.Clear();
            //    }

            //} while (currentAppId > 0);

            ConsoleUtils.JumpLine();
            ConsoleUtils.WriteLine("Thanks for using this app. See you :)", ConsoleColor.White);
        }
    }
}


