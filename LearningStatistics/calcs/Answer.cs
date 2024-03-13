using LearningStatistics.src.distributions.discrete;
using LearningStatistics.src.extensions;

namespace LearningStatistics.calcs
{
    public static class Answer
    {
        public static void Section4_3()
        {
            // 看護婦は30人
            var nurse = 30;
            
            // 15人ずつ2組に分けるので30C15通り
            var comb = nurse.Combination(15);

            Console.WriteLine("4-3: {0}通り", comb);
        }

        public static void Section5_2() 
        {
            var number = new List<double>() { 7, 14, 903, 5, 645, 130, 130, 1300, 26000, 1300000 };
            var money = new List<double>() { 40000000, 10000000, 200000, 10000000, 100000, 1000000, 140000, 10000, 1000, 200 };

            // 宝くじの総本数は1300万通
            var total = 13000000;
            var dist = new GeneralDistribution(number.Select(x => x / total).ToArray());

            Console.WriteLine("5-2 宝くじの期待値は{0}円です。", dist.Expectation(x => (x >= 0 && x < money.Count) ? money[x] : 0));
        }
    }
}
