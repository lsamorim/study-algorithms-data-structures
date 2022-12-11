using BinarySearch.Algorithms;
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

            ConsoleUtils.Write("How many numbers to search in (sample size): ");
            var sampleSize = ConsoleUtils.ReadInteger();

            ConsoleUtils.Write("Type the target number to be searched: ");
            var target = ConsoleUtils.ReadInteger();

            ConsoleUtils.JumpLine();
            ConsoleUtils.WriteLine("Initializing sample list...", ConsoleColor.DarkYellow);
            var sample = (IReadOnlyList<int>)Enumerable.Range(1, sampleSize).ToList();
            ConsoleUtils.WriteLine("Sample list initialized...", ConsoleColor.DarkGreen);
            ConsoleUtils.JumpLine();

            var simpleSearchAlgorithm = new SimpleSearchAlgorithm(sample, target);
            var binarySearchAlgorithm = new BinarySearchAlgorithm(sample, target);

            var result = ExecuteAlgorithm($"{nameof(SimpleSearchAlgorithm)}", simpleSearchAlgorithm);
            ConsoleUtils.JumpLine();
            ExecuteAlgorithm($"{nameof(BinarySearchAlgorithm)}", binarySearchAlgorithm, result.ExecutionTime.TotalMilliseconds);

            Console.ReadKey();
            Console.Clear();
        }

        private AlgorithmResult<int?> ExecuteAlgorithm(string name, AlgorithmBase<int?> algorithm, double? compare = null)
        {
            var result = algorithm.Execute();

            var found = result.Result != null;
            var targetIndex = found ? result.Result.ToString() : "-";
            ConsoleUtils.WriteLine($"[{name}] Result");
            ConsoleUtils.WriteLine($"Found: {found}", found ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed);
            ConsoleUtils.WriteLine($"Target Index: {targetIndex}");
            ConsoleUtils.WriteLine($"Operations: {result.Operations}");
            ConsoleUtils.WriteLine($"Execution Time: {result.ExecutionTime.TotalMilliseconds} ms");

            if (compare != null)
            {
                var baseTime = compare.Value;
                var tookTime = result.ExecutionTime.TotalMilliseconds;

                if (tookTime < baseTime)
                {
                    var p = Math.Round(baseTime / tookTime, 2);
                    ConsoleUtils.WriteLine($"Execution Time Comparison: {compare.Value} ms --> {result.ExecutionTime.TotalMilliseconds} ms ({p}x faster)", ConsoleColor.Green);
                }
                else
                {
                    var p = Math.Round(tookTime / baseTime, 2);
                    ConsoleUtils.WriteLine($"Execution Time Comparison: {compare.Value} ms --> {result.ExecutionTime.TotalMilliseconds} ms ({p}x slower)", ConsoleColor.Red);
                }
            }

            return result;
        }
    }
}
