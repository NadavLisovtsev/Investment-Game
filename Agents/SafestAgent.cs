using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.Agents
{
    public class SafestAgent : InvestAgent
    {
        private int safestStock;

        public SafestAgent()
        {
            safestStock = findSafestStock();
        }

        override public InvestmentData Invest(double money, History hist, int roundNum)
        {
            checkIfInitilized();

            InvestmentData result = makeInvestment(money, roundNum, safestStock, _isTrain);
            return result;
        }

        public int findSafestStock()
        {
            double minLoss = StocksManager.getStocks().Min(st => st.getLossProbability());
            Stock s = StocksManager.getStocks().First<Stock>(st => st.getLossProbability() == minLoss);
            return s._id;
        }

        public override int getStockId(double money, History hist, int roundNum)
        {
            return safestStock;
        }
    }
}