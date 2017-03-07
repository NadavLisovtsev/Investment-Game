using InvestmentGame.HttpClients;
using InvestmentGame.LearningAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.ARPredictors
{
    public class RNNRegressionPredictor : RegressionPredictor
    {
        RNNClient _client = new RNNClient();
        protected override RegressionAlgoClient getClient()
        {
            return _client;
        }
    }
}