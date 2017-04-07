using InvestmentGame.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public static class StocksManager
    {
        private static DAL dal = new DAL(System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ToString());
        private static  string stocksTable = "StocksEarnings";
        private static  string stocksNamesTable = "StocksNames";
      //  private static string stocksDataFolder = @"C:\Users\Sarne\Desktop\Investment Game\StocksData";
        private static string stocksDataFolder = @"C:\Users\Ola\Desktop\Nadav\Investment Game\StocksData";
        private static object initLockObject = new object();

        private static List<Stock> _stocks = new List<Stock>();

        private static Dictionary<int, IRandomGenerator> _stocksUniformGenerators = new Dictionary<int, IRandomGenerator>();

        public static void initialize()
        {
            lock (initLockObject)
            {
                if (dal.isTableEmpty(stocksTable))
                {
                    initStocksInDB();
                }
                initStocks();
            }
        }

        public static Stock getStock(int stockId)
        {
            return _stocks.Find(s => s._id == stockId);
        }

        public static IEnumerable<Stock> getStocks()
        {
            return _stocks;
        }

        public static int getStocksNum()
        {
            return _stocks.Count;
        }

        public static bool HasStocks()
        {
            return !dal.isTableEmpty(stocksTable);
        }

        private static void initStocksInDB()
        {
            Dictionary<int, string> stockIdToName = new Dictionary<int, string>();
          //  Dictionary<int, double> stocksEarnings = new Dictionary<int,double>();
            List<KeyValuePair<int,double>> stocksEarnings = new List<KeyValuePair<int,double>>();

            //read data from files
            int i = 1;
            foreach (string filename in Directory.EnumerateFiles(stocksDataFolder))
            {
               

                string name = Path.GetFileNameWithoutExtension(filename);

                stockIdToName.Add(i, name);

                var reader = new StreamReader(File.OpenRead(filename));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    double earning = Double.Parse(values[0]);
                    int count;
                    if (values[1] == "")
                    {
                        count = 1;
                    }
                    else
                    {
                        count = Int32.Parse(values[1]);
                    }
                 //   int count = Int32.Parse(values[1]);
                    for (int j = 0; j < count; j++)
                    {
                        stocksEarnings.Add(new KeyValuePair<int, double>(i, earning));
                    }
                }
                i++;
            }


            //write stocks name table
            List<List<DALType>> stockNamesData = new List<List<DALType>>();
            foreach (KeyValuePair<int, string> pair in stockIdToName)
            {
                List<DALType> stockNameRow = new List<DALType>();
                stockNameRow.Add(new DALInt(pair.Key));
                stockNameRow.Add(new DALString(pair.Value));
                stockNamesData.Add(stockNameRow);
            }
            dal.writeData(stocksNamesTable, stockNamesData);


            //write stocks earnings table
            List<List<DALType>> stocksEarningsData = new List<List<DALType>>();
            foreach (KeyValuePair<int, double> pair in stocksEarnings)
            {
                List<DALType> stockEarningRow = new List<DALType>();
                stockEarningRow.Add(new DALInt(pair.Key));
                stockEarningRow.Add(new DALDouble(pair.Value));
                stocksEarningsData.Add(stockEarningRow);
            }
            dal.writeData(stocksTable, stocksEarningsData);
        }

        private static void initStocks()
        {
            List<List<DALType>> dbStocksData = new List<List<DALType>>();
            List<DALTypes> columnNameTypes = new List<DALTypes>();
            List<DALTypes> columnEarningsTypes = new List<DALTypes>();

            columnNameTypes.Add(DALTypes.Int);
            columnNameTypes.Add(DALTypes.String);

            columnEarningsTypes.Add(DALTypes.Int);
            columnEarningsTypes.Add(DALTypes.Double);

            List<List<DALType>> dbStocksNamesData = dal.ReadFullTable(stocksNamesTable, columnNameTypes.ToArray());
            List<List<DALType>> ddStocksEarningsData = dal.ReadFullTable(stocksTable, columnEarningsTypes.ToArray());

            // insert earnings data for stocks
            foreach (List<DALType> earningsRow in ddStocksEarningsData)
            {
                int stockId = (int)earningsRow[0].getData();
                if (!hasStock(stockId))
                {
                    _stocks.Add(new Stock(stockId));
                }
                int index = _stocks.FindIndex(s => s._id == stockId);
                _stocks[index].addEarning((double)earningsRow[1].getData());
            }

            // insert name data for stocks
            foreach (List<DALType> nameRow in dbStocksNamesData)
            {
                int stockId = (int)nameRow[0].getData();
                if (!hasStock(stockId))
                {
                    _stocks.Add(new Stock(stockId));
                }
                int index = _stocks.FindIndex(s => s._id == stockId);
                _stocks[index].setName((string)nameRow[1].getData());
            }

            //update unifrom generators
            RandomGeneratorFactory generatorFactory = new RandomGeneratorFactory();
            string generatorName = ConfigurationManager.AppSettings["StocksRandomGeneratorType"];
            foreach(Stock s in _stocks)
            {
                int earnings_num = int.Parse(ConfigurationManager.AppSettings["EarningsPerStock"]);
                _stocksUniformGenerators.Add(s._id, generatorFactory.CreateRandomGenerator(generatorName, 0, earnings_num - 1));
            }

        }

        public static bool hasStock(int id) 
        {
            return _stocks.Exists(s => id == s._id);
        }

        public static IRandomGenerator getGeneratorForStock(int id)
        {
            return _stocksUniformGenerators[id];
        }
    }


    public class noStocksException : Exception
    { }
}