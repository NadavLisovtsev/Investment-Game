using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class RegressionResponseData
    {
        public string Result;

        public  RegressionResponseData()
        {}
        
        public RegressionResponseData(string result)
        {
            Result = result;
        }
    }
}