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

            Option<IApp>? option;
            do
            {
                Greet();
                option = menu.PickAnOption(cleanAfter: true);

                if (option != null)
                {
                    option.Result.Run();
                }

                Console.Clear();
            } while (option != null);
        }
    }
}