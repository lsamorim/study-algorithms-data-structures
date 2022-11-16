namespace Common
{
    public abstract class BaseApp : IApp
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract void Run();

        protected void Greet()
        {
            ConsoleUtils.WriteLine($"***** Welcome to {Name} App *****", ConsoleColor.Green);
        }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
