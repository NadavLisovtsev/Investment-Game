using InvestmentGame.HttpClients;
using InvestmentGame.LearningAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.ARPredictors
{
    public class RFRegressionPredictor : RegressionPredictor
    {
        RFClient _client = new RFClient();
        protected override RegressionAlgoClient getClient()
        {
            return _client;
        }
    }
}