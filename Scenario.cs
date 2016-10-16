using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class Scenario
    {
        private Dictionary<int, ScenarioTurn> _turns = new Dictionary<int,ScenarioTurn>();

        public void addTurn(int turnNum ,ScenarioTurn turn)
        {
            _turns.Add(turnNum, turn);
        }

        public double getStockEarning(int turnNum, int StockNum)
        {
            return _turns[turnNum].getEarningForStock(StockNum);
        }

        public void addEarningToTurn(int turnNum, int stockNum, double earning)
        {
            if (!_turns.ContainsKey(turnNum))
            {
                ScenarioTurn t = new ScenarioTurn();
                t.addStockEarning(stockNum, earning);
                _turns[turnNum] = t;
            }
            else
            {
                _turns[turnNum].addStockEarning(stockNum, earning);
            }
        }
        public double getExpectancy(int scenarioId)
        {
            CommisionFactory commFactory = new CommisionFactory();
            Comission comm = commFactory.GetCommission(ConfigurationManager.AppSettings["CommissionType"]);

            GameManager gm = new GameManager(false);
            gm.relevantScenario = scenarioId;

            AgentsFactory factory = new AgentsFactory();
            InvestAgent agent = factory.CreateAgent(ConfigurationManager.AppSettings["AgentType"], gm, comm, false);

            int startMoney = int.Parse(ConfigurationManager.AppSettings["InitialMoneyAmount"]);
            double currMoney = startMoney;

            History hist = new History();
            int roundNum = 1;
            foreach(KeyValuePair<int, ScenarioTurn> p in _turns) 
            {  
                InvestmentData data = agent.Invest((float)currMoney, hist, p.Key);
                hist.addRecord(new HistoryRecord(data, currMoney, data.endMoney, roundNum));
                currMoney = data.endMoney;
                ++roundNum;
            }
            return currMoney;
        }

        public void DeleteAllData()
        {
            foreach(KeyValuePair<int, ScenarioTurn> p in _turns)
            {
                p.Value.DeleteAllData();
            }
        }
    }
}