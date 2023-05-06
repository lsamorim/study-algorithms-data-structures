using BinarySearch.Algorithms;
using Common;
using Common.Helpers;

namespace BinarySearch.SubApp
{
    public class TextBinarySearchApp : BaseApp
    {
        public override string Name => "Binary Search (Text)";

        public override string Description => "Binary search algorithm - O(log n)";

        protected override void Execute()
        {
            ConsoleUtils.Write("Type the text list to be used in search: ");
            var menu = new ConsoleOptionsMenu<string>("Choose an Type to be executed:");
            menu.AddOption("animals");
            menu.AddOption("cars");
            var sampleListName = menu.PickAnOption();

            if (sampleListName == null)
            {
                return;
            }

            ConsoleUtils.Write("Type the text to be searched: ");
            var target = Console.ReadLine();

            ConsoleUtils.JumpLine();
            ConsoleUtils.WriteLine("Initializing sample list...", ConsoleColor.DarkYellow);
            var textList = GetTextList(sampleListName);

            var index_1 = new List<List<(int LetterCode, int Id)>>();
            for (int i = 0, count = textList.Count; i < count; i++)
            {
                for (int j = 0, wordSize = textList[i].Length; j < wordSize; j++)
                {
                    if (j + 1 > index_1.Count)
                        index_1.Add(new List<(int LetterCode, int Id)>());

                    index_1[j].Add(new(TextHelper.ToLetterCode(textList[i][j]), i));
                    index_1[j] = index_1[j].OrderBy(x => x.LetterCode).ToList();
                }
            }

            ConsoleUtils.WriteLine("Sample list initialized...", ConsoleColor.DarkGreen);
            ConsoleUtils.JumpLine();

            if (target.Length > index_1.Count)
            {
                ConsoleUtils.WriteLine("Impossible to find target text", ConsoleColor.DarkYellow);
            }
            else
            {
                var simpleSearch = ExecuteSimpleSearch(index_1, target);
                var binarySearch = ExecuteBinaryeSearch(index_1, target);

                Resume("TextSimpleSearch", simpleSearch.MatchesIds, simpleSearch.Operations, simpleSearch.TotalExecutionTime);
                ConsoleUtils.JumpLine();
                Resume("TextBinarySearch", binarySearch.MatchesIds, binarySearch.Operations, binarySearch.TotalExecutionTime, simpleSearch.Operations);
            }
        }

        private List<string> GetTextList(string file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "TextBinarySearch", $"{file}.txt");

            var list = File.ReadAllLines(path);
            return list.ToList();
        }

        private (List<int> MatchesIds, int Operations, double TotalExecutionTime) ExecuteSimpleSearch(List<List<(int LetterCode, int Id)>> index_1, string target)
        {
            var results = new List<AlgorithmResult<(int MinIndex, int MaxIndex)?>>();
            var matchedIds = new List<int>();
            for (int i = 0, wordSize = target.Length; i < wordSize; i++)
            {
                var tempSample = index_1[i].Select(x => x.LetterCode).ToArray();

                var targetLetterCode = TextHelper.ToLetterCode(target[i]);
                var simpleSearchRangedAlgorithm = new SimpleSearchRangedAlgorithm(tempSample, targetLetterCode);
                var searchResult = simpleSearchRangedAlgorithm.Execute();

                if (searchResult.Result == null)
                {
                    matchedIds = new List<int>();
                    break;
                }

                results.Add(searchResult);
                var rangedResult = searchResult.Result.Value;

                if (i == 0)
                {
                    for (int matchedIndex = rangedResult.MinIndex, to = rangedResult.MaxIndex; matchedIndex <= to; matchedIndex++)
                    {
                        matchedIds.Add(index_1[i][matchedIndex].Id);
                    }
                }
                else
                {
                    var tempNewMatchedIds = new List<int>();
                    for (int matchedIndex = rangedResult.MinIndex, to = rangedResult.MaxIndex; matchedIndex <= to; matchedIndex++)
                    {
                        var id = index_1[i][matchedIndex].Id;

                        if (matchedIds.Contains(id))
                            tempNewMatchedIds.Add(id);
                    }

                    matchedIds = tempNewMatchedIds;
                    if (matchedIds.Count == 0)
                        break;
                }
            }

            return (matchedIds, results.Sum(r => r.Operations), results.Sum(r => r.ExecutionTime.TotalMilliseconds));
        }

        private (List<int> MatchesIds, int Operations, double TotalExecutionTime) ExecuteBinaryeSearch(List<List<(int LetterCode, int Id)>> index_1, string target)
        {
            var results = new List<AlgorithmResult<(int MinIndex, int MaxIndex)?>>();
            var matchedIds = new List<int>();
            for (int i = 0, wordSize = target.Length; i < wordSize; i++)
            {
                var tempSample = index_1[i].Select(x => x.LetterCode).ToArray();

                var targetLetterCode = TextHelper.ToLetterCode(target[i]);
                var binarySearchRangedAlgorithm = new BinarySearchRangedAlgorithm(tempSample, targetLetterCode);
                var searchResult = binarySearchRangedAlgorithm.Execute();

                if (searchResult.Result == null)
                {
                    matchedIds = new List<int>();
                    break;
                }

                results.Add(searchResult);
                var rangedResult = searchResult.Result.Value;

                if (i == 0)
                {
                    for (int matchedIndex = rangedResult.MinIndex, to = rangedResult.MaxIndex; matchedIndex <= to; matchedIndex++)
                    {
                        matchedIds.Add(index_1[i][matchedIndex].Id);
                    }
                }
                else
                {
                    var tempNewMatchedIds = new List<int>();
                    for (int matchedIndex = rangedResult.MinIndex, to = rangedResult.MaxIndex; matchedIndex <= to; matchedIndex++)
                    {
                        var id = index_1[i][matchedIndex].Id;

                        if (matchedIds.Contains(id))
                            tempNewMatchedIds.Add(id);
                    }

                    matchedIds = tempNewMatchedIds;
                    if (matchedIds.Count == 0)
                        break;
                }
            }

            return (matchedIds, results.Sum(r => r.Operations), results.Sum(r => r.ExecutionTime.TotalMilliseconds));
        }

        private void Resume(string name, List<int> matchesIds, int operations, double executionTime, int? operationsToCompare = null)
        {
            var found = matchesIds.Any();
            var targetIndex = found ? matchesIds[0].ToString() : "-";
            executionTime = Math.Round(executionTime, 2);
            ConsoleUtils.WriteLine($"[{name}] Result");
            ConsoleUtils.WriteLine($"Found: {found}", found ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed);
            ConsoleUtils.WriteLine($"Target Index: {targetIndex}");
            ConsoleUtils.WriteLine($"Operations: {operations}");
            ConsoleUtils.WriteLine($"Execution Time: {executionTime} ms");

            if (operationsToCompare != null)
            {
                var baseOperations = operationsToCompare.Value;

                if (operations < baseOperations)
                {
                    var p = Math.Round(baseOperations / (operations * 1f), 2);
                    ConsoleUtils.WriteLine($"Operations Comparison: {baseOperations} --> {operations} ({p}x faster)", ConsoleColor.Green);
                }
                else
                {
                    var p = Math.Round(operations / (baseOperations * 1f), 2);
                    ConsoleUtils.WriteLine($"Operations Comparison: {baseOperations} --> {operations} ({p}x slower)", ConsoleColor.Red);
                }
            }
        }
    }
}
