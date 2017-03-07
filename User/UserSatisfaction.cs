using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class UserSatisfaction
    {
        public string GeneralSatisfication { get; private set; }
        public string AgentSatisfaction { get; private set; }
        public string Payment { get; private set; }
        public string ParticipateAgain { get; private set; }
        public string Comments { get; private set; }

        public UserSatisfaction(string g, string a, string p, string pa, string c)
        {
            GeneralSatisfication = g;
            AgentSatisfaction = a;
            Payment = p;
            ParticipateAgain = pa;
            Comments = c;
        }
    }
}