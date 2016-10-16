using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.AssymptoticAgent
{
    public class HFuncStockGradeCalculator : IStockGradeCalculator
    {
        private ARGainCombiner _h;

        public HFuncStockGradeCalculator(ARGainCombiner c)
        {
            _h = c;
        }

        public HFuncStockGradeCalculator()
        {
            _h = new LinearARGainCombiner();
        }

        public double calcStockGrade(Stock s, double money, double earnLossAverage, History history)
        {
            AsymptoticAverage avg = new AsymptoticAverage();
            double earningProbability = 1.0 / s.getEarningsCount();
            List<double> earnings = s.getEarnings();
            double sum = 0;

            foreach (double earning in earnings)
            {
                double upToDateAverage = avg.addValueToAverage(earning, earnLossAverage);
                double expectedAdoptionRate = EarnLossToAdoptionRate.getAdoptionRate(upToDateAverage);
                sum += _h.combine(upToDateAverage, earning) * earningProbability;
            }
            return sum;
        }
    }
}