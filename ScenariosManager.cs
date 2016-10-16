using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public static class ScenariosManager
    {
        private static DAL dal = new DAL(System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ToString());
        private static  string scenariosTable = "Scenarios";
        private static string scenariosSummaryTable = "ScenariosSummary";
        private static Dictionary<int, Scenario> _scenarios = new Dictionary<int, Scenario>();
        private static object initLockObject = new object();

        public static void initialize()
        {
            if (!StocksManager.HasStocks())
            {
                throw new noStocksException();
            }
            lock (initLockObject)
            {
                bool updateScenariosSummary = false;
                if (dal.isTableEmpty(scenariosTable))
                {
                    initScenariosInDB();
                    updateScenariosSummary = true;
                }
                initScenarios();
                if (updateScenariosSummary || dal.isTableEmpty(scenariosSummaryTable))
                {
                    initScenariosSummary();
                }
            }
        }

        public static int getScenariosNum()
        {
            return _scenarios.Count;
        }

        public static double getEarning(int scenarioId, int turnNum, int StockId)
        {
            return _scenarios[scenarioId].getStockEarning(turnNum, StockId);
        }

        private static void initScenariosInDB()
        {
            int scenariosNumber = int.Parse(ConfigurationManager.AppSettings["NumberOfScenarios"]);
            int turnsNum = int.Parse(ConfigurationManager.AppSettings["MaxRounds"]);

            List<List<DALType>> writeData = new List<List<DALType>>();
            for (int i = 0; i < scenariosNumber; i++)
            {
                for (int j = 0; j < turnsNum; j++)
                {
                    foreach (Stock s in StocksManager.getStocks())
                    {
                        List<DALType> row = new List<DALType>();

                        row.Add(new DALInt(i + 1)); //scenarioId
                        row.Add(new DALInt(j + 1)); //TurnNum
                        row.Add(new DALInt(s._id)); //srockId
                        row.Add(new DALDouble(s.getEarning())); //stock earning

                        writeData.Add(row);
                    }
                }
            }
            dal.writeData(scenariosTable, writeData);
        }

        private static void initScenarios()
        {
            int scenariosNumber = int.Parse(ConfigurationManager.AppSettings["NumberOfScenarios"]);
            int turnsNum = int.Parse(ConfigurationManager.AppSettings["MaxRounds"]);

            List<DALTypes> columns = new List<DALTypes>();
            columns.Add(DALTypes.Int);
            columns.Add(DALTypes.Int);
            columns.Add(DALTypes.Int);
            columns.Add(DALTypes.Double);
            List<List<DALType>> dbData = dal.ReadFullTable(scenariosTable, columns.ToArray());

            foreach(KeyValuePair<int, Scenario> p in _scenarios)
            {
                p.Value.DeleteAllData();
            }

            foreach (List<DALType> row in dbData)
            {
                int scenarioId = (int)row[0].getData();
                int turnNum = (int)row[1].getData();
                int stockId = (int)row[2].getData();
                double earning = (double)row[3].getData();
                
                if(!_scenarios.ContainsKey(scenarioId))
                {
                    Scenario s = new Scenario();
                    ScenarioTurn turn = new ScenarioTurn();
                    turn.addStockEarning(stockId, earning);
                    s.addTurn(turnNum, turn);
                    _scenarios[scenarioId] = s;
                }
                else
                {
                    _scenarios[scenarioId].addEarningToTurn(turnNum, stockId, earning);
                }
            }

        }

        private static void initScenariosSummary()
        {
            if(_scenarios == null || _scenarios.Count == 0)
            {
                throw new noLoadedScenariosException();
            }
            foreach(KeyValuePair<int, Scenario> p in _scenarios)
            {
                int id = p.Key;
                double expectancy = p.Value.getExpectancy(id);
                List<List<DALType>> values = new List<List<DALType>>();
                List<DALType> row = new List<DALType>();
                row.Add(new DALInt(id)) ;
                row.Add(new DALDouble(expectancy));
                values.Add(row);
                dal.writeData(scenariosSummaryTable, values);
            }

        }
    }

    public class noLoadedScenariosException : Exception
    {}

}