namespace Common
{
    public struct AlgorithmResult<TResult>
    {
        public TResult Result { get; private set; }
        public int Operations { get; private set; }
        public TimeSpan ExecutionTime { get; private set; }

        public AlgorithmResult(TResult result, int operations, TimeSpan executionTime)
        {
            Result = result;
            Operations = operations;
            ExecutionTime = executionTime;
        }
    }
}
