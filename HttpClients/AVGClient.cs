using InvestmentGame.LearningAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.HttpClients
{
    public class AVGClient : RegressionAlgoClient
    {
        private const string _algoName = "AVG";

        override protected string getAlgoName()
        {
            return _algoName;
        }
    }
}