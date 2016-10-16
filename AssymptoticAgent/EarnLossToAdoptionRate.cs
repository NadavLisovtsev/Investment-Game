using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace InvestmentGame.AssymptoticAgent
{
    public static class EarnLossToAdoptionRate
    {
        private static Dictionary<double, double> ElToArFunc = null;
        private static int _roundFactor = 2;
        private static DAL dal = new DAL(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        private static object lockObject = new object();
       

        public static double getAdoptionRate(double earnLoss)
        {
            lock(lockObject)
            {
                if(ElToArFunc == null)
                {
                    ElToArFunc = calcFunc();
                }
            }
            // Print ElToArFunc -- Debug Puproses
            /*
            var l = ElToArFunc.OrderBy(item => item.Key);
            var dic = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);

            using (StreamWriter outputFile = new StreamWriter(@"C:\Users\Ola\Desktop\EltoArFunc.txt"))
            {
                foreach (KeyValuePair<double, double> pair in dic)
                {
                    outputFile.WriteLine("{0},{1}", pair.Key, pair.Value);
                }
            }

            */
            // End of printing -- Debug Purposes
            double roundedEarnLoss  = Math.Round(earnLoss, _roundFactor);
            if(ElToArFunc.ContainsKey(roundedEarnLoss))
            {
                return roundedEarnLoss;
            }
            List<double> keys = ElToArFunc.Keys.ToList<double>();
            keys.Sort();
            if (roundedEarnLoss < keys[0]) 
            {
                return ElToArFunc[keys[0]] * (roundedEarnLoss / keys[0]);
            }
            if(roundedEarnLoss > keys[keys.Count-1])
            {
                return ElToArFunc[keys[keys.Count-1]] * (roundedEarnLoss / keys[keys.Count-1]);
            }
            int i = 0;
            double currKey = keys[0]; 
            while(currKey < roundedEarnLoss && i < keys.Count - 1)
            {
                i++;
                currKey = keys[i];
            }
            double length = keys[i] - keys[i - 1];
            double alpha = 1 - (roundedEarnLoss - keys[i - 1]) / length;
            double beta = 1 - (keys[i] - roundedEarnLoss) / length;
            return (alpha * ElToArFunc[keys[i-1]] + beta * ElToArFunc[keys[i]]) / 2.0;
        }

        private static Dictionary<double, double> calcFunc()
        {
            List<string> users = getUsersList();

            Dictionary<double, List<double>> preFunc = new Dictionary<double, List<double>>();
            foreach(string user in users)
            {
                string UserARandEarnLossQuery = String.Format(ConfigurationManager.AppSettings["GetUserARAndEarnLossQuery"], user);
                List<DALTypes> ARandGainColumns = new List<DALTypes>();
                ARandGainColumns.Add(DALTypes.Double);
                ARandGainColumns.Add(DALTypes.Double);

                List<List<DALType>> ARandGainResults = dal.ReadData(UserARandEarnLossQuery, ARandGainColumns.ToArray());

                List<KeyValuePair<double, double>> ARandGain = new List<KeyValuePair<double, double>>();
                foreach(List<DALType> row in ARandGainResults)
                {
                    ARandGain.Add(new KeyValuePair<double, double>((double)row[0].getData(),(double)row[1].getData()));
                }

                AsymptoticAverage avg = new AsymptoticAverage();                
                for(int i = 1; i < ARandGain.Count; i++)
                {
                    double currAR = ARandGain[i].Key;
                    List<double> prevGains = new List<double>();
                    for(int j = 0; j < i; j++)
                    {
                        prevGains.Add(ARandGain[j].Value);
                    }

                    double averageGainUntilNow = Math.Round(avg.calcAverage(prevGains), _roundFactor);
                    if(preFunc.ContainsKey(averageGainUntilNow))
                    {
                        preFunc[averageGainUntilNow].Add(currAR);
                    }
                    else
                    {
                        preFunc[averageGainUntilNow] = new List<double>();
                        preFunc[averageGainUntilNow].Add(currAR);
                    }
                }
            }

            Dictionary<double, double> func = new Dictionary<double, double>();
            foreach(KeyValuePair<double, List<double>> pair in preFunc)
            {
                double value = pair.Value.Count > 1 ? pair.Value.Average() : pair.Value[0];
                func[pair.Key] = value;
            }
            return func;
        }

        private static List<string> getUsersList()
        {
            string allUsersQuery = ConfigurationManager.AppSettings["GetAllUsersQuery"];
            List<DALTypes> allUsersColumns = new List<DALTypes>();
            allUsersColumns.Add(DALTypes.String);

            List<string> users = new List<string>();
            List<List<DALType>> result = dal.ReadData(allUsersQuery, allUsersColumns.ToArray());
            foreach (List<DALType> row in result)
            {
                users.Add((string)row[0].getData());
            }
            return users;
            
           
        }
    }
}