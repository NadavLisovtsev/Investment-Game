using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class UserInfo
    {
        public string Gender { get; private set; }
        public string Age { get; private set; }
        public string Education { get; private set; }
        public string Nationality { get; private set; }
        public string Reason { get; private set; }
        public string Mobile { get; private set; }

        public UserInfo(string g, string age, string e, string n, string r, string m)
        {
            Gender = g;
            Age = age;
            Education = e;
            Nationality = n;
            Reason = r;
            Mobile = m;
        }

    }
}