using InvestmentGame.AssymptoticAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public abstract class RegressionAgent : ARPredictionBasedAgent
    {
        private OptimalAgent _fallBackAgent = new OptimalAgent();

        protected override InvestAgent getFallBackAgent()
        {
            return _fallBackAgent;
        }

    }
}