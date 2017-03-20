using InvestmentGame.AssymptoticAgent;
using InvestmentGame.UtilitiesService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace InvestmentGame.LearningAgents
{
    public abstract class ARPredictionBasedAgent : HistoryBasedAgent
    {

        private IStockGradeCalculator _stockCalculator;

        abstract protected IARPredictor getPredictor();

        public ARPredictionBasedAgent()
        {
            //Service1Client _utilsClient = new Service1Client();
            IARPredictor predictor = getPredictor();
            _stockCalculator = (IStockGradeCalculator)Activator.CreateInstance(Type.GetType(ConfigurationManager.AppSettings["StockGradeCalculator"]));
            _stockCalculator.setARPredictor(predictor);
        }

        protected override int findRelevantStock(double money, List<double> ARList, List<double> earnLossList, History history)
        {
            IEnumerable<Stock> stocks = StocksManager.getStocks();
            double maxGrade = -100;
            int maxGradeStockNum = 0;
            double currMoney = history.getCurrMoney();
            double currAR = money / currMoney;

            ARList.Add(currAR);

            foreach (Stock s in stocks)
            {
                double grade = _stockCalculator.calcStockGrade(s, money, ARList, earnLossList, history);
                if (grade > maxGrade)
                {
                    maxGrade = grade;
                    maxGradeStockNum = s._id;
                }
            }
            return maxGradeStockNum;
        }        

    }
}