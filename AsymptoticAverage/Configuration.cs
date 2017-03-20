using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymptoticAverage
{
    static class MyConfiguration
    {

        private static Dictionary<string, string> confDict = new Dictionary<string, string>();
        static MyConfiguration()
        {
            confDict.Add("AsymptoticAlpha", "0.5");
            confDict.Add("BetaDistPositiveAlpha", "1");
            confDict.Add("BetaDistPositiveBeta", "4");
            confDict.Add("BetaDistNegativeAlpha", "0.7");
            confDict.Add("BetaDistNegativeBeta", "4");
        }

        public static string getSetting(string settingName)
        {
            return confDict[settingName];
        }
    }


}
