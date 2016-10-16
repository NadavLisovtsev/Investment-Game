using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame.AssymptoticAgent
{
    public class AsymptoticAverage
    {
        private double _alpha = double.Parse(ConfigurationManager.AppSettings["AsymptoticAlpha"]);
        private IFloatPreCalc _preCalc = null;
        
        public AsymptoticAverage()
        {
            _preCalc = new BetaCumulativeDistPreCalc();
        }

        public AsymptoticAverage(IFloatPreCalc preCalculation)
        {
            _preCalc = preCalculation;
        }

        public double calcAverage(List<double> l)
        {
            double currVal = _preCalc != null ? _preCalc.doCalc(l[0]) : l[0];
            if (l.Count == 1)
            {
                return _alpha * currVal;
            }
            double t = calcAverage(l.GetRange(1, l.Count - 1));

            return _alpha * currVal + (1 - _alpha) * t;
        }
        

        public double addValueToAverage(double val, double average)
        {
            double currVal = _preCalc != null ? _preCalc.doCalc(val) : val;
            return _alpha * currVal + (1 - _alpha) * average; 
        }
    }
}