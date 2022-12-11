using BinarySearch.SubApp;
using Common;

namespace BinarySearch
{
    public class BinarySearchApp : BaseApp
    {
        public override string Name => "Binary Search";
        public override string Description => "Binary search algorithm - O(log n)";

        public override void Run()
        {
            var menu = new ConsoleOptionsMenu<IApp>("Choose an Type to be executed:");
            menu.AddOption(new NumberBinarySearchApp());

            IApp? app;
            while (true)
            {
                Greet();
                app = menu.PickAnOption(cleanAfter: true);

                if (app == null)
                    break;

                app.Run();
            }

            Console.Clear();
        }
    }
}