using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class AgentsFactory
    {
        private Dictionary<string, Type> agentsDict;

        public AgentsFactory()
        {
            agentsDict = new Dictionary<string, Type>();

            agentsDict.Add("Optimal", Type.GetType("InvestmentGame.OptimalAgent"));
            agentsDict.Add("Safest", Type.GetType("InvestmentGame.Agents.SafestAgent"));
            agentsDict.Add("ConstStock", Type.GetType("InvestmentGame.Agents.OneStockAgent"));
            agentsDict.Add("Random", Type.GetType("InvestmentGame.Agents.RandomAgent"));
            agentsDict.Add("Asymptotic", Type.GetType("InvestmentGame.AssymptoticAgent.AsymptoticAgent"));
            agentsDict.Add("RegressionNN", Type.GetType("InvestmentGame.LearningAgents.RegressionAgentNN"));
            agentsDict.Add("RegressionSVM", Type.GetType("InvestmentGame.LearningAgents.RegressionAgentSVM"));
            agentsDict.Add("RegressionRF", Type.GetType("InvestmentGame.Agents.RegressionAgentRF"));
            agentsDict.Add("RegressionRNN", Type.GetType("InvestmentGame.Agents.RegressionAgentRNN"));
            agentsDict.Add("RegressionAVG", Type.GetType("InvestmentGame.Agents.RegressionAgentAVG"));
            agentsDict.Add("RegressionLR", Type.GetType("InvestmentGame.Agents.RegressionAgentLR"));


        }
        public InvestAgent CreateAgent(string name, GameManager gm, Comission c, bool isTrain)
        {
            InvestAgent agent = (InvestAgent)Activator.CreateInstance(agentsDict[name]);
            agent.UpdateGameManager(gm);
            agent.UpdateCommission(c);
            agent.SetMode(isTrain);
            return agent;

        }
    }
}