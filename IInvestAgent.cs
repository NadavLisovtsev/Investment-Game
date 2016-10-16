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
    }

    public class NoGameManagerException : Exception 
    { }

    public class NoCommission : Exception
    { }
}
