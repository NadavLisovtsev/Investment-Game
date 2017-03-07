using InvestmentGame.ARPredictors;
using InvestmentGame.AssymptoticAgent;
using InvestmentGame.HttpClients;
using InvestmentGame.LearningAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.Agents
{
    public class RegressionAgentLR : RegressionAgent
    {
        LRRegressionPredictor _predictor = new LRRegressionPredictor();

        private LRClient _regressionClient = new LRClient();

        protected override IARPredictor getPredictor()
        {
            return _predictor;
        }

        protected override int getMinRoundNum()
        {
            return _regressionClient.getMinRounds();
        }
    }
}