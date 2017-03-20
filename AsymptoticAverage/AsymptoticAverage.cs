using AsymptoticAverage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsymptoticAverage
{
    public class AsymptoticAverageClass
    {
        private double _alpha = double.Parse(MyConfiguration.getSetting("AsymptoticAlpha"));
        private IFloatPreCalc _preCalc = null;
        
        public AsymptoticAverageClass()
        {
            _preCalc = new BetaCumulativeDistPreCalc();
        }

        public AsymptoticAverageClass(IFloatPreCalc preCalculation)
        {
            _preCalc = preCalculation;
        }

        public double calcAverage(List<double> l)
        {
            double currVal = _preCalc != null ? _preCalc.doCalc(l[0]) : l[0];
            if (l.Count == 1)
            {
                return currVal;
            }
            if (l.Count == 2)
            {
                double secondVal = _preCalc != null ? _preCalc.doCalc(l[1]) : l[1];

                return _alpha * currVal + (1 - _alpha) * secondVal;
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