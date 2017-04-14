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

        public double calcStockGrade(Stock s, double investedMoney, List<double> ARList, List<double> earnLossList, History history, int roundNum, Comission comm)
        {
            double earningProbability = 1.0 / s.getEarningsCount();
            List<double> earnings = s.getEarnings();
            double sum = 0;
            List<HistoryRecord> investmentsRecords = history.getInvestmentsHistory();
            double currTotalMoney = investmentsRecords[investmentsRecords.Count - 1]._currMoney;

            foreach (double earning in earnings)
            {
                earnLossList.Add(earning);
                double earnMoney = (1 + earning) * investedMoney;
                double commissionPercent = comm.takeCommision(investedMoney, earning).Item2;
                double commissionMoney = comm.takeCommision(investedMoney, earning).Item1;
                double endInvestmentMoney =  earnMoney - commissionMoney;
                double endMoney = currTotalMoney - investedMoney + endInvestmentMoney;

                InvestmentData investmentData = new InvestmentData(s._id, investedMoney, earning, earnMoney, commissionMoney, commissionPercent, endInvestmentMoney);
                history.addRecord(new HistoryRecord(investmentData, currTotalMoney, endMoney, roundNum));
                double expectedAdoptionRate = _predictor.predict(endMoney, roundNum + 1, history);
                sum += expectedAdoptionRate * earningProbability;
 //               sum += (currTotalMoney - investedMoney + investedMoney * (1 + earning)) * expectedAdoptionRate * earningProbability;               
            }
            return sum;

        }
    }
}