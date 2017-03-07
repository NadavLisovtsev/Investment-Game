using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class SVMClient : RegressionAlgoClient
    {
        private const string _algoName = "SVM";

        override protected string getAlgoName()
        {
            return _algoName;
        }
    }
}