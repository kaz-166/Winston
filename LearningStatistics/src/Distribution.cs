namespace LearningStatistics.src
{
    public class Distribution
    {
        private readonly int PSEUDO_INFINITY = 10000;

        private readonly Func<int, double> _probability;

        public Distribution(Func<int, double> probability) 
        {
            _probability = probability;
        }

        /// <summary>
        /// Calculate Expectation
        /// </summary>
        /// <param name="phy"></param>
        /// <returns></returns>
        public double Expectation(Func<double, double> phy) 
        {
            var sum = 0.0;
            for(var x = -PSEUDO_INFINITY; x < PSEUDO_INFINITY; x++) 
            {
                sum += phy(x) * _probability(x);
            }

            return sum;
        }

        /// <summary>
        /// Calculate Skewness: E[(X - u)^2]
        /// </summary>
        /// <param name="phy"></param>
        /// <returns></returns>
        public double Variant(Func<double, double> phy) 
        {
            // V[X] = E[X^2] - (E[X])^2
            return Expectation(x => phy(x) * phy(x)) - Expectation(x => phy(x)) * Expectation(x => phy(x));
        }

        /// <summary>
        /// Calculate Skewness: E[(X - u)^3]
        /// </summary>
        /// <param name="phy"></param>
        /// <returns></returns>
        public double Skewness(Func<double, double> phy)
        {
            return 0.0;
        }

        /// <summary>
        /// Calculate Kurtosis: E[(X - u)^4]
        /// </summary>
        /// <param name="phy"></param>
        /// <returns></returns>
        public double Kurtosis(Func<double, double> phy)
        {
            return 0.0;
        }

        public double Moment(int dimension, double expectation)
        {
            return Expectation(x => Math.Pow(x - expectation, dimension));
        }
    }
}
