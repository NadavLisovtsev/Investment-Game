using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace InvestmentGame
{
    public  class GameManager
    {
        private static object lockObject = new object();
        private static bool isInitialized = false;

        public  int relevantScenario {get; set;}
        public int relevantTrainingScenario { get; private set; }

        public GameManager()
        {
            initGameManager();
        }

        public GameManager(bool isRealManager)
        {
            if(isRealManager)
            {
                initGameManager();
            }
            
        }

        public void initGameManager()
        {
            lock (lockObject)
            {
                if (!isInitialized)
                {
                    initGame();
                }
            }

           // relevantScenario = Global.scenarioNumGenerator.getRandomNum();
            relevantScenario = 1;
            Thread.Sleep(10);
            relevantTrainingScenario = Global.trainingScenarioNumGenerator.getRandomNum();
        }

        private double getEarning(int turnNum, int stockNum, bool isTraining)
        {
            int scenario = isTraining ? relevantTrainingScenario : relevantScenario;
            return ScenariosManager.getEarning(scenario, turnNum, stockNum);
        }
        
        public Tuple<double, double, double> investOnStock(double money, int turnNum, int stockNum, bool isTraining = false)
        {
            double earn = getEarning(turnNum, stockNum, isTraining);
            double result_money = money * (1 + earn);
            double earnMoney = earn * money;
            return new Tuple<double, double, double>(result_money, earn, earnMoney);
        }

        private static void initGame()
        {
                StocksManager.initialize();
                ScenariosManager.initialize();
                isInitialized = true;
        }
    }
}