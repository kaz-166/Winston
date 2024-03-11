namespace LearningStatistics.src
{
    /// <summary>
    /// Class of Histogram
    /// </summary>
    public class Histogram
    {
        private readonly int[] _histogram;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="histogram">Histogram</param>
        public Histogram(int[] histogram)
        {
            _histogram = histogram;
        }

        /// <summary>
        /// Calculate Entropy
        /// </summary>
        /// <returns>Entropy</returns>
        /// <remarks>This method uses "Common" logarithms.</remarks>
        public double Entropy()
        {
            var relativeFrequency = _histogram
                    .Select(e => e / (double)_histogram.Sum())
                    .ToArray();

            var sum = 0.0;
            for (var i = 0; i < relativeFrequency.Length; i++)
            {
                sum += relativeFrequency[i] * Math.Log10(relativeFrequency[i]);
            }

            return -sum;
        }
    }
}
