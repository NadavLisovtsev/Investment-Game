using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class FromInvestmentCommision : Comission
    {
        override
        public Tuple<double, double> takeCommision(double investment, double gain)
        {
            return new Tuple<double, double>(investment * (percent / 100), percent);
        }
    }
}