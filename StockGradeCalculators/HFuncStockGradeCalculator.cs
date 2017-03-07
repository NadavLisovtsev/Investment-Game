using InvestmentGame.UtilitiesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.AssymptoticAgent
{
    public class HFuncStockGradeCalculator : IStockGradeCalculator
    {
        private ARGainCombiner _h;
        private  Service1Client _utilsClient = new Service1Client();
        private IARPredictor _predictor;

        
        public HFuncStockGradeCalculator(ARGainCombiner c)
        {
            _h = c;
        }

        public HFuncStockGradeCalculator()
        {
            _h = new LinearARGainCombiner();
        }

        public void setARPredictor(IARPredictor predictor)
        {
            _predictor = predictor;
        }

        public double calcStockGrade(Stock s, double money, List<double> ARList, List<double> earnLossList, History history)
        {
            double earningProbability = 1.0 / s.getEarningsCount();
            List<double> earnings = s.getEarnings();
            double sum = 0;

            foreach (double earning in earnings)
            {
                earnLossList.Add(earning);
                double expectedAdoptionRate = _predictor.predict(ARList, earnLossList);
                sum += _h.combine(expectedAdoptionRate, earning) * earningProbability;
            }
            return sum;
        }
    }
}