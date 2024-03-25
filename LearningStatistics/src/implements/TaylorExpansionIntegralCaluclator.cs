using LearningStatistics.src.interfaces;
using System.Linq.Expressions;

namespace LearningStatistics.src.implements
{
    public class TaylorExpansionIntegralCaluclator : IIntegralCalculator
    {
        public double Integral(Func<double, double> func, double a, double b)
        {
            throw new NotImplementedException();
        }

        public double Integral(Func<double, double, double> func, double a, double b)
        {
            throw new NotImplementedException();
        }

        private void TaylorApproximation() 
        {
        
        }

        private class TaylorPolynomial
        {
            private Func<double, double> _polynomial;

            public TaylorPolynomial(Func<double, double> func, int dimension)
            {
                Expression<Func<double, int, double>> x = (x, p) => Math.Pow(x, p);

                var expr = Expression.Multiply(Expression.Constant(Derive(func)(0)), x);

                for (var i = 1; i < dimension; i++)
                {
                    expr = Expression.Add(expr, Expression.Multiply(Expression.Constant(Derive(func, i)(0)), x));
                }
                var lambda = Expression.Lambda<Func<double, double>>(expr);

                _polynomial = lambda.Compile();
            }

            public Func<double, double> Func() => _polynomial;

            public double Value(double x) => _polynomial(x);


            private Func<double, double> Derive(Func<double, double> func)
            {
                const double delta = 0.001;
                Expression<Func<double, double>> x = x => x;
                Expression<Func<double, double>> f = x => func(x);

                var body = Expression.Divide(
                        Expression.Subtract
                        (
                            Expression.Assign(f, Expression.Add(x, Expression.Constant(delta))),
                            Expression.Assign(f, x)
                        ),
                        Expression.Constant(delta));

                Expression<Func<double, double>> lambda = Expression.Lambda<Func<double, double>>(body);

                return lambda.Compile();
            }

            private Func<double, double> Derive(Func<double, double> func, int count)
            {
                if (count == 0)
                {
                    return Derive(func);
                }


                Func<double, double> f = func;
                for (var i = 0; i < count; i++)
                {
                    f = Derive(f);
                }
                return f;
            }
        }
    }
}
