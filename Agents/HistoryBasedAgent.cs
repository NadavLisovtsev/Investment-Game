using InvestmentGame.ForDebug;
using InvestmentGame.UtilitiesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public abstract class HistoryBasedAgent : InvestAgent
    {
        abstract protected int getMinRoundNum();
        abstract protected InvestAgent getFallBackAgent();
        abstract protected int findRelevantStock(double money, List<double> ARList, List<double> earnLoossList, History history);

        public override InvestmentData Invest(double money, History hist, int roundNum)
        {
            checkIfInitilized();

            int stockId = getStockId(money, hist, roundNum);

            DebugFileWriter.writeToFile("output.txt", stockId.ToString());

            InvestmentData result = makeInvestment(money, roundNum, stockId, _isTrain);
            return result;
        }

        public override int getStockId(double money, History hist, int roundNum)
        {
            return roundNum < getMinRoundNum() ?
                   getFallBackAgent().getStockId(money, hist, roundNum) :
                   calcStockForRegularRound(money, hist, roundNum);
        }

        private int calcStockForRegularRound(double money, History history, int roundNum)
        {
            List<double> earnLossList = history.getEarnLossList();
            List<double> ARList = history.getARList();

            int stockId = findRelevantStock(money, ARList, earnLossList, history);

            return stockId;
        }

    }
}