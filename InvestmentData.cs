using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class InvestmentData
    {
        public int stockId;
        public double investmentMoney;
        public double earn;
        public double earnMoney;
        public double commission;
        public double commission_percent;
        public double endMoney;

        public InvestmentData(int StockId, double Money, double Earn, double EarnMoney, double Comm, double cp, double e)
        {
            stockId = StockId;
            investmentMoney = Money;
            earn = Earn;
            earnMoney = EarnMoney;
            commission = Comm;
            commission_percent = cp;
            endMoney = e;
        }

    }
}