using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public abstract class Comission
    {

        protected double percent = double.Parse(ConfigurationManager.AppSettings["CommissionPercent"]);

        public abstract Tuple<double, double> takeCommision(double investment, double gain);
    }
}