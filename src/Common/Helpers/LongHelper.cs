namespace Common.Helpers
{
    public static class LongHelper
    {
        public static IEnumerable<long> Range(long start, long count)
        {
            var range = new long[count];
            for (long i = 0; i < count; i++)
            {
                range[i] = start + i;
            }

            return range;
        }
    }
}
