namespace Common
{
    public class SimpleSearchAlgorithm : AlgorithmBase<int?>
    {
        private int[] _sample;
        private int _target = 0;

        public SimpleSearchAlgorithm(int[] sample, int target)
        {
            _sample = sample;
            _target = target;
        }

        protected override int? ExecuteAlgorithm()
        {
            if (_target < _sample[0] || _target > _sample[_sample.Length-1])
                return null;

            for (int i = 0, count = _sample.Length; i < count; i++)
            {
                base.RegisterOperation();
                var guess = _sample[i];

                if (guess == _target)
                    return i;
            }

            return null;
        }
    }
}
