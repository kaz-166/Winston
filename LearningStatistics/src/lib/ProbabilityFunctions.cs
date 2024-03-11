namespace LearningStatistics.src.lib
{
    public class ProbabilityFunctions
    {
        public static double Saikoro(int x)
        {
            if (x > 0 && x <= 6)
            {
                return 1 / (double)6;
            }
            else
            {
                return 0;

            }
        }
    }
}
