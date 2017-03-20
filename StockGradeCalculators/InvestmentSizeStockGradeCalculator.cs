using InvestmentGame.UtilitiesService;
using InvestmentGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.AssymptoticAgent
{
    public class InvestmentSizeStockGradeCalculator : IStockGradeCalculator
    {
        private static UtilsClient _utilsClient = new UtilsClient();
        private IARPredictor _predictor;

        public void setARPredictor(IARPredictor predictor)
        {
            _predictor = predictor;
        }

        public double calcStockGrade(Stock s, double money, List<double> ARList, List<double> earnLossList, History history)
        {
            double earningProbability = 1.0 / s.getEarningsCount();
            List<double> earnings = s.getEarnings();
            double sum = 0;
            List<HistoryRecord> investmentsRecords = history.getInvestmentsHistory();
            double currTotalMoney = investmentsRecords[investmentsRecords.Count - 1]._currMoney;

            foreach (double earning in earnings)
            {
                earnLossList.Add(earning);
                double expectedAdoptionRate = _predictor.predict(ARList, earnLossList);
                sum += (currTotalMoney - money + money * (1 + earning)) * expectedAdoptionRate * earningProbability;               
            }
            return sum;

        }
    }
}