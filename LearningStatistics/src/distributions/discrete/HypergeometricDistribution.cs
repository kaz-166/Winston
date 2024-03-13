using LearningStatistics.src.extensions;

namespace LearningStatistics.src.distributions.discrete
{
    public class HypergeometricDistribution : DiscreteDistributionBase
    {
        public HypergeometricDistribution(int N, int M, int n)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(N, 0);
            ArgumentOutOfRangeException.ThrowIfLessThan(M, 0);
            ArgumentOutOfRangeException.ThrowIfLessThan(n, 0);
            ArgumentOutOfRangeException.ThrowIfLessThan(N, M);

            _func = x => (double)Int128.DivRem((M.Permutation(x) * (N - M).Permutation(n - x)), N.Permutation(n)).Quotient;
        }
    }
}
