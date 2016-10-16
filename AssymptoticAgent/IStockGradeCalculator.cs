using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentGame.AssymptoticAgent
{
    public interface IStockGradeCalculator
    {
        double calcStockGrade(Stock s, double money, double earnLossAverage, History history);
    }
}
