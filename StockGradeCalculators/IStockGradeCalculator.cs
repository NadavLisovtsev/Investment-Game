using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentGame.AssymptoticAgent
{
    public interface IStockGradeCalculator
    {
        void setARPredictor(IARPredictor predictor);
        double calcStockGrade(Stock s, double money, List<double> ARList, List<double> earnLossList, History history);
    }
}
