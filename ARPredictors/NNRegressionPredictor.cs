using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class NNRegressionPredictor : RegressionPredictor
    {
        NNClient _client = new NNClient();
        protected override RegressionAlgoClient getClient()
        {
            return _client;
        }
    }
}