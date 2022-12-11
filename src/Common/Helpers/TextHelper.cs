namespace Common.Helpers
{
    public static class TextHelper
    {
        public static IReadOnlyList<int> ToLetterCode(string text)
        {
            return text.Select(c => ToLetterCode(c)).ToList();
        }

        public static int ToLetterCode(char character)
        {
            return (int)character % 32;
        }
    }
}
