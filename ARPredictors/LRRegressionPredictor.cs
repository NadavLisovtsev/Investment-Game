using InvestmentGame.HttpClients;
using InvestmentGame.LearningAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.ARPredictors
{
    public class LRRegressionPredictor : RegressionPredictor
    {
        LRClient _client = new LRClient();
        protected override RegressionAlgoClient getClient()
        {
            return _client;
        }
    }
}