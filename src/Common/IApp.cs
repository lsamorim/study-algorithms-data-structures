namespace Common
{
    public interface IApp
    {
        string Name { get; }

        string Description { get; }

        void Run();
    }
}