using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class FromGainCommision : Comission
    {
        override
        public Tuple<double, double> takeCommision(double investment, double gain)
        {
            if (gain > 0)
            {
                return new Tuple<double, double>(gain * (percent / 100), percent);
            }
            else
            {
                return new Tuple<double, double>(0, 0);
            }
        }
    }
}