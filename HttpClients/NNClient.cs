using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class NNClient : RegressionAlgoClient
    {
        private const string _algoName = "NN";

        override protected string getAlgoName()
        {
            return _algoName;
        }
    }
}