namespace Common.Helpers
{
    public static class TextHelper
    {
        public static IReadOnlyList<int> ToNumberList(string text)
        {
            return text.Select(c => (int)c % 32).ToList();
        }
    }
}
