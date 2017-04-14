using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentGame.AssymptoticAgent
{
    public interface IARPredictor
    {
       // double predict(List<double> ARs, List<double> gains);
        double predict(double money, int roundNum,  History hist);

    }
}
