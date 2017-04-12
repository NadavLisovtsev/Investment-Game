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
            double maxExpectation = StocksManager.getStocks().Max(st => st.getExcpectation());
            Stock s = StocksManager.getStocks().First<Stock>(st => st.getExcpectation() == maxExpectation);
            return s._id;
        }

        public override int getStockId(double money, History hist, int roundNum)
        {
            return optimalStock;
        }
    }
}