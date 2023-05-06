using BinarySearch.SubApp;
using Common;

namespace BinarySearch
{
    public class BinarySearchApp : BaseApp
    {
        public override string Name => "Binary Search";
        public override string Description => "Binary search algorithm - O(log n)";

        protected override void Execute()
        {
            var menu = new ConsoleOptionsMenu<IApp>("Choose an Type to be executed:");
            menu.AddOption(new NumberBinarySearchApp());
            menu.AddOption(new TextBinarySearchApp());

            IApp? app;
            while (true)
            {
                app = menu.PickAnOption(cleanAfter: true);

                if (app == null)
                    break;

                app.Run(cleanAfter: true);
            }
        }
    }
}