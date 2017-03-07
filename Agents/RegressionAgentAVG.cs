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
    public class RegressionAgentAVG : RegressionAgent
    {
        AVGRegressionPredictor _predictor = new AVGRegressionPredictor();

        private AVGClient _regressionClient = new AVGClient();

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