using InvestmentGame.ForDebug;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using InvestmentGame.UtilitiesService;
using InvestmentGame.LearningAgents;
using InvestmentGame.Utils;

namespace InvestmentGame.AssymptoticAgent
{
    public class AsymptoticAgent : ARPredictionBasedAgent
    {

        private UtilsClient _utilClient = new UtilsClient();  
        private OptimalAgent _fallBackAgent = new OptimalAgent();
        private EarnLossAverageToAR _predictor = new EarnLossAverageToAR();
        private const int _minRoundNum = 2;

        protected override InvestAgent getFallBackAgent()
        {
            return _fallBackAgent;
        }

        protected override int getMinRoundNum()
        {
            return _minRoundNum;
        }

        protected override IARPredictor getPredictor()
        {
            return _predictor;
        }
    }
}  