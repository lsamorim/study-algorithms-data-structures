namespace Common
{
    public class ConsoleOptionsMenu<TOption>
    {
        private readonly string _greetings;
        public Dictionary<int, TOption> Options { get; private set; }

        public ConsoleOptionsMenu(string greetings)
        {
            Options = new Dictionary<int, TOption>();
            _greetings = greetings;
        }

        public void AddOptions(IEnumerable<TOption> options)
        {
            foreach (var option in options)
            {
                AddOption(option);
            }
        }

        public void AddOption(TOption option)
        {
            var id = Options.Count + 1;
            Options.Add(id, option);

        }

        public TOption? PickAnOption(bool cleanBefore = false, bool cleanAfter = false)
        {
            int optionId = -1;
            while (optionId == -1)
            {
                if (cleanBefore)
                    Console.Clear();

                ConsoleUtils.WriteLine(_greetings, ConsoleColor.Cyan);
                ConsoleUtils.JumpLine();

                foreach (var option in Options)
                {
                    ConsoleUtils.WriteLine($"{option.Key} - {option.Value}");
                }
                ConsoleUtils.WriteLine("0 - Exit");

                ConsoleUtils.Write("Please type: ");
                optionId = ConsoleUtils.ReadInteger();

                if (optionId != 0)
                {
                    if (!Options.TryGetValue(optionId, out _))
                    {
                        ConsoleUtils.JumpLine();
                        ConsoleUtils.WriteLine($"Invalid Option: {optionId} - Please choose a valid option.", ConsoleColor.Red);
                        optionId = -1;
                    }
                }
            }

            if (cleanAfter)
                Console.Clear();

            return optionId == 0 ? default : Options[optionId];
        }
    }

    public class Option<TResult>
    {
        public int Id { get; set; }

        public TResult Result { get; set; }
    }
}
