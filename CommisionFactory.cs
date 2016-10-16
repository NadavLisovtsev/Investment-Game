using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class CommisionFactory
    {
          private Dictionary<string, Type> CommsDict;

          public CommisionFactory()
        {
            CommsDict = new Dictionary<string, Type>();

            CommsDict.Add("Investment", Type.GetType("InvestmentGame.FromInvestmentCommision"));
            CommsDict.Add("Gain", Type.GetType("InvestmentGame.FromGainCommision"));
        }
        public Comission GetCommission(string name)
        {
            return (Comission)Activator.CreateInstance(CommsDict[name]);
        }
    }
}