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

            Tuple<double, double, double> t = _gm.investOnStock(money, roundNum, optimalStock, _isTrain);
            double result_money = t.Item1;
            double earn = t.Item2;
            double earnMoney = t.Item3;

            Tuple<double, double> t2 = _comm.takeCommision(money, earn);
            double commission_percent = t2.Item2;
            double commission_taken = t2.Item1;

            return new InvestmentData(optimalStock, money, earn, earnMoney, commission_taken, commission_percent, result_money - commission_taken);

        }

        public int findOptimalStock()
        {
            double maxAverage = StocksManager.getStocks().Max(st => st.getAverageEarning());
            Stock s = StocksManager.getStocks().First<Stock>(st => st.getAverageEarning() == maxAverage);
            return s._id;
        }
    }
}