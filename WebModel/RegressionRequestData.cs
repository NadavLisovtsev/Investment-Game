using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class RegressionRequestData
    {
        public string Name;
        public Dictionary<string, List<double>> RawData;

        public RegressionRequestData(string algoName, List<double> ARs, List<double> gains)
        {
            Name = algoName;
            RawData = new Dictionary<string, List<double>>();
            RawData["AR"] = ARs;
            RawData["Gain"] = gains;
        }
    }
}