using InvestmentGame.WebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class RegressionRequestData
    {
        public string Name;
        public List<RoundData> GameData;

        public RegressionRequestData(string algoName, double money, int roundNum, History hist)
        {
            Name = algoName;
            GameData = initRawData(money, roundNum, hist);
        }

        private List<RoundData> initRawData(double money, int roundNum, History hist)
        {
            List<RoundData> historyList = hist.getRoundDataList();
            RoundData currRoundData = new RoundData();
            currRoundData.Money = money;
            currRoundData.RoundNum = roundNum;
            historyList.Add(currRoundData);
            return historyList;
        }


    }
}