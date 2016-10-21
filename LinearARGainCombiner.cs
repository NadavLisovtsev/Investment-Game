using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class LinearARGainCombiner : ARGainCombiner
    {
        private double _arAlpha = double.Parse(ConfigurationManager.AppSettings["arAlpha"]);
        private double _gainBeta = double.Parse(ConfigurationManager.AppSettings["gainBeta"]);
        public override double combine(double ar, double gain)
        {
            return _arAlpha * ar + _gainBeta * gain;
        }
    }
}