using Common;

namespace BinarySearch.SubApp
{
    public class NumberBinarySearchApp : BaseApp
    {
        public override string Name => "Binary Search (Numbers)";

        public override string Description => "Binary search algorithm - O(log n)";

        public override void Run()
        {
            Greet();

            Console.ReadKey();
        }
    }
}
