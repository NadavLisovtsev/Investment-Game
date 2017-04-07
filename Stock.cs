using InvestmentGame.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class Stock
    {
        public int _id { get; private set; }
        public string _name { get; private set; }
        private List<double> _earnings = new List<double>();

        public Stock(int id, string name, List<double> earnings)
        {
            _id = id;
            _name = name;
            _earnings = earnings;
        }

        public Stock(int id)
        {
            _id = id;
            _name = "";
        }

        public void setName(string name)
        {
            _name = name;
        }

        public void setEarnings(List<double> earnings)
        {
            _earnings = earnings;
        }

        public void addEarning(double earning)
        {
            _earnings.Add(earning); 
        }

        public double getEarning()
        {
            IRandomGenerator generator = StocksManager.getGeneratorForStock(_id);

            return _earnings[generator.getRandomNum()];
        }

        public double getAverageEarning()
        {
            return _earnings.Average();
        }

        public bool equalToId(int id)
        {
            return id == _id;
        }

        public double getExcpectation()
        {
            double result = 1;
            foreach(double earning in _earnings)
            {
                result *= (1 + earning);
            }
            return result;
        }

        public int getEarningsCount()
        {
            return _earnings.Count;
        }

        public List<double> getEarnings()
        {
            return _earnings;
        }
    }
}