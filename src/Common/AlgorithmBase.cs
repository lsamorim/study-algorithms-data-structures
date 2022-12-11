using System.Diagnostics;

namespace Common
{
    public abstract class AlgorithmBase<TResult>
    {
        private int _operations = 0;

        public AlgorithmResult<TResult> Execute()
        {
            var stopWatch = Stopwatch.StartNew();
            var result = ExecuteAlgorithm();
            stopWatch.Stop();

            return new AlgorithmResult<TResult>(result, _operations, stopWatch.Elapsed);
        }

        protected void RegisterOperation()
        {
            Task.Delay(0).Wait();
            _operations++;
        }

        protected abstract TResult ExecuteAlgorithm();
    }
}
