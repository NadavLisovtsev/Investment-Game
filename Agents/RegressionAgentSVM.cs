using InvestmentGame.AssymptoticAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class RegressionAgentSVM : RegressionAgent
    {
        SVMRegressionPredictor _predictor = new SVMRegressionPredictor();
        
        private SVMClient _regressionClient = new SVMClient();

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