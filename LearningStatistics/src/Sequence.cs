namespace LearningStatistics.src
{
    /// <summary>
    /// Number of Sequence
    /// </summary>
    public class Sequence
    {
        private readonly int[] _sequence;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sequence">Numbers of Sequence</param>
        public Sequence(int[] sequence)
        {
            _sequence = sequence;
        }

        /// <summary>
        /// Calculate Arithmetic Mean
        /// </summary>
        /// <returns>Arithmetic Mean</returns>
        public double ArithmeticMean()
        {
            var sum = 0.0;
            for (var i = 0; i < _sequence.Length; i++)
            {
                sum += _sequence[i];
            }
            return sum / _sequence.Length;
        }

        /// <summary>
        /// Calculate Mean Differnce
        /// </summary>
        /// <returns>Mean Differnce</returns>
        public double MeanDiffernce()
        {
            var sum = 0.0;
            for (var i = 0; i < _sequence.Length; i++)
            {
                for (var j = 0; j < _sequence.Length; j++)
                {
                    sum += Math.Abs(_sequence[i] - _sequence[j]);
                }
            }
            return sum / ((double)_sequence.Length * _sequence.Length);
        }

        /// <summary>
        /// Calculate Gini Index
        /// </summary>
        /// <returns>Gini Index</returns>
        public double GiniIndex()
        {
            return MeanDiffernce() / (2 * _sequence.Length * _sequence.Length * ArithmeticMean());
        }
    }
}
