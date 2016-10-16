using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class HistoryRecord
    {
        public  InvestmentData _investmentData {get; private set;}
        public double _prevMoney { get; private set; }
        public double _currMoney { get; private set; }
        public int _roundNum { get; private set; }

        public HistoryRecord(InvestmentData investmentData, double prevMoney, double currMoney, int roundNum)
        {
            _investmentData = investmentData;
            _prevMoney = prevMoney;
            _currMoney = currMoney;
            _roundNum = roundNum;
        }
    }
}