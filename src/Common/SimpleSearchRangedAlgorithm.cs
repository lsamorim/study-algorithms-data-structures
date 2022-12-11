namespace Common
{
    public class SimpleSearchRangedAlgorithm : AlgorithmBase<(int MinIndex, int MaxIndex)?>
    {
        private IReadOnlyList<int> _sample;
        private int _target = 0;

        public SimpleSearchRangedAlgorithm(IReadOnlyList<int> sample, int target)
        {
            _sample = sample;
            _target = target;
        }

        protected override (int MinIndex, int MaxIndex)? ExecuteAlgorithm()
        {
            if (_target < _sample[0] || _target > _sample[_sample.Count - 1])
                return null;

            int? minIndex = null;
            int? maxIndex = null;

            for (int i = 0, count = _sample.Count; i < count; i++)
            {
                base.RegisterOperation();
                var guess = _sample[i];

                if (guess == _target)
                {
                    if (minIndex == null)
                        minIndex = maxIndex = i;
                    else
                        maxIndex = i;
                }
                else
                {
                    if (maxIndex != null)
                        return (minIndex.Value, maxIndex.Value);
                }
            }

            if (minIndex == null)
                return null;

            return (minIndex.Value, maxIndex.Value);
        }
    }
}
