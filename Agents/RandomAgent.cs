using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace InvestmentGame.Agents
{
    public class RandomAgent : InvestAgent
    {
        private Random rng = new Random(unchecked(Environment.TickCount * 31));

        override public InvestmentData Invest(double money, History hist, int roundNum)
        {
            checkIfInitilized();

            InvestmentData result = makeInvestment(money, roundNum, getRandomStock(), _isTrain);
            return result;
        }

        public override int getStockId(double money, History hist, int roundNum)
        {
            return getRandomStock();
        }

        private int getRandomStock()
        {
            Thread.Sleep(50);
            int stocksNum = StocksManager.getStocksNum();
            return rng.Next(1, stocksNum);
        }
    }
}