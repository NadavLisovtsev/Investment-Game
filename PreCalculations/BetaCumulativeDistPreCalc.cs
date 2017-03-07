using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathNet.Numerics.Distributions;
using System.Configuration;

namespace InvestmentGame.AssymptoticAgent
{
    public class BetaCumulativeDistPreCalc : IFloatPreCalc
    {
        private double _positiveAlpha = double.Parse(ConfigurationManager.AppSettings["BetaDistPositiveAlpha"]);
        private double _positiveBeta = double.Parse(ConfigurationManager.AppSettings["BetaDistPositiveBeta"]);
        private double _negativeAlpha = double.Parse(ConfigurationManager.AppSettings["BetaDistNegativeAlpha"]);
        private double _negativeBeta = double.Parse(ConfigurationManager.AppSettings["BetaDistNegativeBeta"]);

        public double doCalc(double x)
        {
            if (x > 0)
            {
                return Beta.CDF(_positiveAlpha, _positiveBeta, x);
            }
            else if(x < 0)
            {
                return (-1) * Beta.CDF(_negativeAlpha, _negativeBeta, (-1) * x);
            }
            return x;
        }
    }
}