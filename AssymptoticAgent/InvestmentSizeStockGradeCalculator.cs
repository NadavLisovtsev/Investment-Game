using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.AssymptoticAgent
{
    public class InvestmentSizeStockGradeCalculator : IStockGradeCalculator
    {
        public double calcStockGrade(Stock s, double money, double earnLossAverage, History history)
        {
            AsymptoticAverage avg = new AsymptoticAverage();
            double earningProbability = 1.0 / s.getEarningsCount();
            List<double> earnings = s.getEarnings();
            double sum = 0;
            List<HistoryRecord> investmentsRecords = history.getInvestmentsHistory();
            double currTotalMoney = investmentsRecords[investmentsRecords.Count - 1]._investmentData.endMoney;
            

            foreach (double earning in earnings)
            {
                double upToDateAverage = avg.addValueToAverage(earning, earnLossAverage);
                double expectedAdoptionRate = EarnLossToAdoptionRate.getAdoptionRate(upToDateAverage);
                sum += (currTotalMoney - money + money * (1 + earning)) * expectedAdoptionRate * earningProbability;               
            }
            return sum;
        }
    }
}