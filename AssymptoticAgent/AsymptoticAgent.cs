using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame.AssymptoticAgent
{
    public class AsymptoticAgent : InvestAgent
    {

        private IStockGradeCalculator _stockCalculator;
        public AsymptoticAgent()
        {
            _stockCalculator = (IStockGradeCalculator)Activator.CreateInstance(Type.GetType(ConfigurationManager.AppSettings["StockGradeCalculator"]));
        }

        override public InvestmentData Invest(double money, History hist, int roundNum)
        {
            int stockId;
            checkIfInitilized();


            if(roundNum == 1)
            {
                stockId = calcStockForFirstRound(money);
            } 
            else
            {
                stockId = calcStockForRegularRound(money, hist, roundNum);
            }
            
           Tuple<double, double, double> t =  _gm.investOnStock(money, roundNum, stockId, _isTrain);
           double result_money = t.Item1;
           double earn = t.Item2;
           double earnMoney = t.Item3;

           Tuple<double, double> t2 = _comm.takeCommision(money, earn);
           double commission_percent = t2.Item2;
           double commission_taken = t2.Item1;

           return new InvestmentData(stockId, money, earn, earnMoney, commission_taken, commission_percent, result_money - commission_taken);
        }

        private int calcStockForFirstRound(double money)
        {
            OptimalAgent optimalAgent = new OptimalAgent();

            return optimalAgent.findOptimalStock();
        }

        private int calcStockForRegularRound(double money, History history, int roundNum)
        {
            List<double> earnLossList = history.getEarnLossList();
            AsymptoticAverage asymAverage = new AsymptoticAverage();
            double prevAverage = asymAverage.calcAverage(earnLossList);

            int stockId = findRelevantStock(money, prevAverage, history);

            return stockId;
        }

        private int findRelevantStock(double money, double earnLossAverage, History history)
        {
            IEnumerable<Stock> stocks = StocksManager.getStocks();
            double maxGrade = -100;
            int maxGradeStockNum = 0;
            foreach(Stock s in stocks)
            {
                double grade = _stockCalculator.calcStockGrade(s, money, earnLossAverage, history);
                if(grade > maxGrade)
                {  
                    maxGrade = grade;
                    maxGradeStockNum = s._id;
                }
            }
            return maxGradeStockNum;
        }

    }
}  