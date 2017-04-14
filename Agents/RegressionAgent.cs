using InvestmentGame.AssymptoticAgent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public abstract class RegressionAgent : ARPredictionBasedAgent
    {
        private InvestAgent _fallBackAgent = null;
    
        protected override InvestAgent getFallBackAgent()
        {
            if (_fallBackAgent == null)
            {
                AgentsFactory factory = new AgentsFactory();
                _fallBackAgent = factory.CreateAgent(ConfigurationManager.AppSettings["RegressionFallBackAgent"], _gm, _comm, _isTrain);
            }
            return _fallBackAgent;
        }

    }
}