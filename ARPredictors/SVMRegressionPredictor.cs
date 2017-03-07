using InvestmentGame.AssymptoticAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class SVMRegressionPredictor : RegressionPredictor
    {
        SVMClient _client = new SVMClient();
        protected override RegressionAlgoClient getClient()
        {
            return _client;
        }
    }
}