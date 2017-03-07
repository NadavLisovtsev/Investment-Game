using InvestmentGame.AssymptoticAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    abstract public class RegressionPredictor : IARPredictor
    {
        abstract protected RegressionAlgoClient getClient();

        public double predict(List<double> ARs, List<double> gains)
        {
            RegressionAlgoClient client = getClient();
            return client.getPrediction(ARs, gains);
        }
    }
}