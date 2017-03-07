using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentGame
{
    public abstract class InvestAgent
    {
        protected GameManager _gm = null;
        protected Comission _comm = null;
        protected bool _isTrain;

        abstract public InvestmentData Invest(double money, History hist, int roundNum);
        abstract public int getStockId(double money, History hist, int roundNum);

        public void UpdateGameManager(GameManager gm)
        {
            _gm = gm;
        }
        public void UpdateCommission(Comission c)
        {
            _comm = c;
        }
        public void SetMode(bool isTrain)
        {
            _isTrain = isTrain;
        }

        protected void checkIfInitilized()
        {
            if (_gm == null)
            {
                throw new NoGameManagerException();
            }
            if (_comm == null)
            {
                throw new NoCommission();
            }
        }

        protected InvestmentData makeInvestment(double money, int roundNum, int stockId, bool _isTrain)
        {
            Tuple<double, double, double> t = _gm.investOnStock(money, roundNum, stockId, _isTrain);
            double result_money = t.Item1;
            double earn = t.Item2;
            double earnMoney = t.Item3;

            Tuple<double, double> t2 = _comm.takeCommision(money, earn);
            double commission_percent = t2.Item2;
            double commission_taken = t2.Item1;

            return new InvestmentData(stockId, money, earn, earnMoney, commission_taken, commission_percent, result_money - commission_taken);

        }
    }

    public class NoGameManagerException : Exception 
    { }

    public class NoCommission : Exception
    { }
}
