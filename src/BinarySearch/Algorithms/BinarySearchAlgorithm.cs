using Common;

namespace BinarySearch.Algorithms
{
    public class BinarySearchAlgorithm : AlgorithmBase<int?>
    {
        private IReadOnlyList<int> _sample;
        private int _lesser = 0;
        private int _greater = 0;
        private int _target = 0;
        private int GuessIndex => (int)((_lesser + (long)_greater) / 2);

        public BinarySearchAlgorithm(IReadOnlyList<int> sample, int target)
        {
            _sample = sample;
            _lesser = 0;
            _greater = _sample.Count - 1;

            _target = target;
        }

        protected override int? ExecuteAlgorithm()
        {
            if (_target < _sample[0] || _target > _sample[_sample.Count - 1])
                return null;

            while (_lesser <= _greater)
            {
                RegisterOperation();
                var guess = _sample[GuessIndex];

                if (guess == _target)
                    return GuessIndex;

                if (guess < _target)
                    _lesser = GuessIndex + 1;
                else
                    _greater = GuessIndex - 1;
            }

            return null;
        }
    }
}
