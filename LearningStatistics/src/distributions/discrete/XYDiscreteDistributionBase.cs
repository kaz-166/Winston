using LearningStatistics.src.extensions;

namespace LearningStatistics.src.distributions.discrete
{
    internal class XYDiscreteDistributionBase : AbstractDistribution<Tuple<int, int>>
    {
        private readonly Func<Tuple<int, int>, double> _func;
    
        /// <summary>
        /// E[XY]
        /// </summary>
        /// <returns></returns>
        public override double Expectation()
        {
            Func<Tuple<int, int>, double> f = x => x.Item1 * x.Item2 * _func(x);
            return f.Sum();
        }

        public override double Expectation(Func<Tuple<int, int>, double> phy)
        {
            throw new NotImplementedException();
        }

        public override double Kurtosis()
        {
            throw new NotImplementedException();
        }

        public override double Moment(int dimension)
        {
            throw new NotImplementedException();
        }

        public override double Skewness()
        {
            throw new NotImplementedException();
        }

        public override double StdDeviation()
        {
            throw new NotImplementedException();
        }

        public override double StdMoment(int dimension)
        {
            throw new NotImplementedException();
        }

        public override double Value(Tuple<int, int> x)
        {
            return _func(x);
        }

        /// <summary>
        /// Calculate Covariance
        /// </summary>
        /// <returns></returns>
        public override double Variance()
        {
            throw new NotImplementedException();
        }
    }
}
