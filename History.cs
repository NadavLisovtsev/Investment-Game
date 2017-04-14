using InvestmentGame.WebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class History
    {
        private List<HistoryRecord> history = new List<HistoryRecord>();
          
        public List<HistoryRecord> getInvestmentsHistory()
        {
            return history;
        } 

        public void  addRecord(HistoryRecord record)
        {
            history.Add(record);
        }

        public List<double> getEarnLossList()
        {
            List<double> earnLossList = new List<double>();
            foreach(HistoryRecord record in history)
            {
                earnLossList.Add(record._investmentData.earn);
            }
            return earnLossList;
        }

        public List<double> getARList()
        {
            List<double> arList = new List<double>();
            foreach(HistoryRecord record in history)
            {
                double money = record._prevMoney;
                double investment = record._investmentData.investmentMoney;
                arList.Add(investment / money);
            }
            return arList;
        }

        public double getCurrMoney()
        {
            return history[history.Count - 1]._currMoney;
        }

        public List<RoundData> getRoundDataList()
        {
            List<RoundData> resultList = new List<RoundData>();
            foreach(HistoryRecord record in history)
            {
                RoundData roundData = new RoundData();
                roundData.AR = record._investmentData.investmentMoney / record._prevMoney;
                roundData.CommissionMoney = record._investmentData.commission;
                roundData.Gain = record._investmentData.earn;
                roundData.Money = record._prevMoney;
                roundData.RoundNum = record._roundNum;
                resultList.Add(roundData);
            }
            return resultList;
        }
    }
}