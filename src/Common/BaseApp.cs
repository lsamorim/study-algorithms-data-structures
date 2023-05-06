namespace Common
{
    public abstract class BaseApp : IApp
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public void Run(bool cleanBefore = false, bool cleanAfter = false)
        {
            if (cleanBefore)
                Console.Clear();

            Greet();
            Execute();

            Console.ReadKey();

            if (cleanAfter)
                Console.Clear();
        }

        private void Greet()
        {
            ConsoleUtils.WriteLine($"***** Welcome to {Name} App *****", ConsoleColor.Green);
        }

        protected abstract void Execute();

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
