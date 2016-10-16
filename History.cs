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
    }
}