using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class OptimalAgent : InvestAgent
    {
        private int optimalStock;

        public OptimalAgent()
        {
            optimalStock = findOptimalStock();
        }

        override public InvestmentData Invest(double money, History hist, int roundNum)
        {
            checkIfInitilized();

            InvestmentData result = makeInvestment(money, roundNum, optimalStock, _isTrain);
            return result;
        }

        public int findOptimalStock()
        {
            double maxAverage = StocksManager.getStocks().Max(st => st.getAverageEarning());
            Stock s = StocksManager.getStocks().First<Stock>(st => st.getAverageEarning() == maxAverage);
            return s._id;
        }

        public override int getStockId(double money, History hist, int roundNum)
        {
            return findOptimalStock();
        }
    }
}