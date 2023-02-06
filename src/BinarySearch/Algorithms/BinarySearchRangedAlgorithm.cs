using Common;

namespace BinarySearch.Algorithms
{
    public class BinarySearchRangedAlgorithm : AlgorithmBase<(int MinIndex, int MaxIndex)?>
    {
        private int[] _sample;
        private int _lesser = 0;
        private int _greater = 0;
        private int _target = 0;
        private int GuessIndex => (int)((_lesser + (long)_greater) / 2);

        public BinarySearchRangedAlgorithm(int[] sample, int target)
        {
            _sample = sample;
            _target = target;
        }

        protected override (int MinIndex, int MaxIndex)? ExecuteAlgorithm()
        {
            if (_target < _sample[0] || _target > _sample[_sample.Length - 1])
                return null;

            var minIndex = ExecuteAlgorithm(true, 0);

            if (minIndex == null)
                return null;

            var maxIndex = ExecuteAlgorithm(false, minIndex.Value);

            return new(minIndex.Value, maxIndex.Value);
        }

        private int? ExecuteAlgorithm(bool findFirstIndex, int startLesser)
        {
            _lesser = startLesser;
            _greater = _sample.Length - 1;

            int? index = null;
            while (_lesser <= _greater)
            {
                RegisterOperation();
                var guess = _sample[GuessIndex];

                if (guess == _target)
                {
                    index = GuessIndex;

                    if (findFirstIndex)
                        _greater = GuessIndex - 1;
                    else
                        _lesser = GuessIndex + 1;
                }
                else
                {
                    if (guess < _target)
                        _lesser = GuessIndex + 1;
                    else
                        _greater = GuessIndex - 1;
                }
            }

            return index;
        }
    }
}
