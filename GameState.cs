using System.Web;
using System.Text;
using System.Web.UI;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace InvestmentGame
{
    public class GameState
    {
        public const int REFRESH_RATE = 4;
       // public const int NUM_OF_GOATS = 20;
        public const int START_ROUND = 3; //from which round to start the goats
        public DateTime start_Date;
        public Boolean time_is_up;  //why the game ended, was it because time up?
        public DateTime end_Date;
        public List<int> ducksArr;  //contains zeros for rounds without ducks and 1's for rounds with ducks and 2 for rounds with goats
        public List<DateTime> user_FoundArr; //the times that the user found ducks
        public List<DateTime> user_MissedArr; //the times that the user missed ducks
        public List<DateTime> user_FoundGoatsArr; //the times that the user found ducks
        public List<DateTime> user_MissedGoatsArr; //the times that the user missed ducks
        public int gameNumber;
        public int falseImageClickCounter;  //count the number of times the user clicked an image that was not a duck
        public bool changeDuckPos; //true if the duck position had changed (at the last minute of the game)

        public List<double> wearFactor;
        public List<double> alpha;
        private Random random;
        //for Debug
        public double r1;
        


        public void userMissedGoat(DateTime curentT)
        {
            user_MissedGoatsArr.Add(curentT);
            //wearFactor.Add(wearFactor[wearFactor.Count - 1] * 0.99);
            wearFactor.Add(1);
            alpha.Add(0.6 * 0 + 0.4 * alpha[alpha.Count - 1]);
            prepperDuckArr();
        }
        public void userFoundGoat(DateTime curentT)
        {
            user_FoundGoatsArr.Add(curentT);
            wearFactor.Add(1);
            alpha.Add(0.9 * 1 + 0.1 * alpha[alpha.Count - 1]);
            prepperDuckArr();
        }
        public void thereWasNoGoat()
        {
            wearFactor.Add(wearFactor[wearFactor.Count - 1] * 0.999);
            alpha.Add(alpha[alpha.Count - 1]);
            prepperDuckArr();
        }

        private void prepperDuckArr()
        {
            //if there is no duck NEXT round
            if (ducksArr[gameNumber+1] == 0 && gameNumber>=START_ROUND)
            {
               
                r1 = random.NextDouble();
                if (r1 > alpha[alpha.Count - 1] * wearFactor[wearFactor.Count - 1])
                {
                 //   r = rand.NextDouble();
                 //   if (r < 0.5)
                    //make sure there is no duck there
                    if(ducksArr[gameNumber + 1]==0)
                        ducksArr[gameNumber + 1] = 2;
                        
               
                }
          
            }
        }
       // public DateTime curentT;
        public Boolean isThereAgoat()
        {
            if (ducksArr[gameNumber] == 2)
                return true;
            return false;
        }
        public Boolean wasThereAgoatLastTurn()
        {
            if (gameNumber == 0)
                return false;
            if (ducksArr[gameNumber - 1] == 2)
                return true;
            return false;
        }
        public Boolean isThereAduck()
        {
            if (ducksArr[gameNumber] == 1)
                return true;
            return false;
        }
        public Boolean wasThereAduckLastTurn()
        {
            if (gameNumber == 0)
                return false;
            if (ducksArr[gameNumber-1] == 1)
                return true;
            return false;
        }
        public void setEndTime() { end_Date = DateTime.UtcNow; }
	    public GameState(int exp_time)
	    {
            start_Date = DateTime.UtcNow;
            time_is_up = false;
            gameNumber = 0;
            falseImageClickCounter = 0;
            random = new Random(DateTime.UtcNow.Millisecond);
            ducksArr=new List<int>();
            user_FoundArr = new List<DateTime>();
            user_MissedArr = new List<DateTime>();
            user_FoundGoatsArr = new List<DateTime>();
            user_MissedGoatsArr = new List<DateTime>();
            changeDuckPos = false;
            wearFactor = new List<double>();
            alpha = new List<double>();
            wearFactor.Add(1);
            alpha.Add(1);
            r1 = 0;
            
            //int ducksNum=random.Next(MINIMUM_DUCKS, MAXIMUM_DUCKS+1);
            /*
            int ducksNum = 5;
            int numberOfRounds =((exp_time * 60) / REFRESH_RATE)-1;
            int sizeOfInterval = numberOfRounds / (ducksNum);
            List<int> tmp=new List<int>();
            int j = sizeOfInterval;
            while (tmp.Count < ducksNum-1)
            {
                int x = random.Next(j - sizeOfInterval+3,j+1);
                if (!tmp.Contains(x))
                {
                    tmp.Add(x);
                    j += sizeOfInterval;
                }
            }
            //setting the last duck to be in the first hlf of the last round interval
            int x1 = random.Next(j - sizeOfInterval, j -(sizeOfInterval/2)+1);
            while(tmp.Contains(x1))
                x1 = random.Next(j - sizeOfInterval, j -(sizeOfInterval/2)+1);
            if (!tmp.Contains(x1))
            {
                tmp.Add(x1);
            }

            for (int i = 0; i < numberOfRounds+1; i++)
            {
                if (tmp.Contains(i))
                    ducksArr.Add(1);
                else
                    ducksArr.Add(0);
            }
            //To be on the safe side with the times, clicking a duck is less than 5 seconds
            for(int i=0;i<=ducksNum+1;i++)
                ducksArr.Add(0);
            */
           



            int numberOfRounds = ((exp_time * 60) / REFRESH_RATE) - 1;
            int x = random.Next(5, numberOfRounds - 5);

            for (int i = 0; i < numberOfRounds + 1; i++)
            {
                if (x==i)
                    ducksArr.Add(1);
                else
                    ducksArr.Add(0);
            }
            //To be on the safe side with the times, clicking on a duck/goat is less than 4 seconds
            for (int i = 0; i < 100; i++)
                ducksArr.Add(0);
	    }
    }
}