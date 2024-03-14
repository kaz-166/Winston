using LearningStatistics.src.extensions;

namespace LearningStatistics.src.distributions.discrete
{
    // 綺麗だけど動かない
    internal class XYDiscreteDistributionBase
    {
        private readonly Func<int, int, double> _func;

        /// <summary>
        /// Marginal Probability Distribution X
        /// </summary>
        protected readonly DiscreteDistributionBase _mpdX;

        /// <summary>
        /// Marginal Probability Distribution Y
        /// </summary>
        protected readonly DiscreteDistributionBase _mpdY;

        public XYDiscreteDistributionBase()
        {
            _mpdX = new DiscreteDistributionBase();
            _mpdY = new DiscreteDistributionBase();
        }

        /// <summary>
        /// Marginal Probability Distribution X
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double MarginalProbabilityDistributionX(int x)
        {
            return _mpdX.Value(x);
        }

        /// <summary>
        /// Marginal Probability Distribution Y
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public double MarginalProbabilityDistributionY(int y)
        {
            return _mpdY.Value(y);
        }

        /// <summary>
        /// Calculate Covariance(X, Y)
        /// </summary>
        /// <returns></returns>
        public double Covariance() 
        {
            return Expectation((x, y) => x * y) - _mpdX.Expectation(x => x) * _mpdY.Expectation(y => y);
        }

        /// <summary>
        /// Calculate Expectation(X, Y)
        /// </summary>
        /// <param name="phy"></param>
        /// <returns></returns>
        public double Expectation(Func<int, int, double> phy)
        {
            Func<int, int, double> f = (x, y) => phy(x, y) * _func(x, y);
            return f.Sum();
        }

    }
}
