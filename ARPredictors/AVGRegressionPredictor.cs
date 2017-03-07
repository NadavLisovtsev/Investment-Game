using InvestmentGame.HttpClients;
using InvestmentGame.LearningAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.ARPredictors
{
    public class AVGRegressionPredictor : RegressionPredictor
    {
        AVGClient _client = new AVGClient();
        protected override RegressionAlgoClient getClient()
        {
            return _client;
        }
    }
}