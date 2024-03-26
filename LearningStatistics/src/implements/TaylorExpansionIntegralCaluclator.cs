using LearningStatistics.src.extensions;
using LearningStatistics.src.interfaces;

namespace LearningStatistics.src.implements
{
    public class TaylorExpansionIntegralCaluclator : IIntegralCalculator
    {
        public double Integral(Func<double, double> func, double a, double b)
        {
            var polynomial = new TaylorPolynomial(func);
            return polynomial.Integral()(b) - polynomial.Integral()(a);
        }

        public double Integral(Func<double, double, double> func, double a, double b)
        {
            throw new NotImplementedException();
        }

        private class TaylorPolynomial
        {
            private Func<double, double> _polynomial;

            private Func<double, double> _integralPoly;

            public TaylorPolynomial(Func<double, double> func)
            {
                Func<int, Func<double, double>> poly = p => x => func.Differentiate(p)(0) / (double)p.Factorial() * Math.Pow(x, p);
                Func<int, Func<double, double>> integralPoly = p => x => func.Differentiate(p)(0) / (double)(p + 1).Factorial() * Math.Pow(x, p + 1);

                _polynomial = x => func(0) + poly(1)(x) + poly(2)(x) + poly(3)(x) + poly(4)(x);
                _integralPoly = x => func(0) * x + integralPoly(1)(x) + integralPoly(2)(x) + integralPoly(3)(x) + integralPoly(4)(x);
            }

            public Func<double, double> Integral() => _integralPoly;
        }
    }
}
