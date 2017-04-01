using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame.Agents
{
    public class OneStockAgent : InvestAgent
    {
         private int constStock;

         public OneStockAgent()
        {
            constStock = int.Parse(ConfigurationManager.AppSettings["ConstStockId"]);
        }

        override public InvestmentData Invest(double money, History hist, int roundNum)
        {
            checkIfInitilized();

            InvestmentData result = makeInvestment(money, roundNum, constStock, _isTrain);
            return result;
        }

        public override int getStockId(double money, History hist, int roundNum)
        {
            return constStock;
        }
    }
}