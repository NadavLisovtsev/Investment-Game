using InvestmentGame.AssymptoticAgent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class RegressionAgentNN : RegressionAgent
    {
        
        NNRegressionPredictor _predictor = new NNRegressionPredictor();

        private NNClient _regressionClient = new NNClient();

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