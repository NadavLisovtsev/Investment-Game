using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class ScenarioTurn
    {
        private Dictionary<int, double> stocksEarnings = new Dictionary<int, double>();

        public void addStockEarning(int stockId, double earning)
        {
            stocksEarnings.Add(stockId, earning);
        }

        public double getEarningForStock(int stockId)
        {
            return stocksEarnings[stockId];
        }

        public void DeleteAllData()
        {
           stocksEarnings = new Dictionary<int, double>();
        }
    }
}