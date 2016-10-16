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
            agentsDict.Add("Asymptotic", Type.GetType("InvestmentGame.AssymptoticAgent.AsymptoticAgent"));
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