using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace InvestmentGame.RandomGenerators
{
    public class ListShuffleGenerator : IRandomGenerator
    {
        
        private  Random rng = new Random(unchecked(Environment.TickCount * 31));  

        private List<int> _shuffledList = new List<int>();
        private int _currIndex = 0;

        public ListShuffleGenerator(int mn, int mx) // include both!!
        {
            Thread.Sleep(50);
            rng = new Random();
            List<int> listToShuffle = new List<int>();
            for (int i = mn; i <= mx; ++i )
            {
                listToShuffle.Add(i);
            }


           _shuffledList = shuffle(listToShuffle);
        }

        public int getRandomNum()
        {
            if (_currIndex >= _shuffledList.Count())
            {
                _shuffledList = shuffle(_shuffledList);
                _currIndex = 0;
            }
            int result = _shuffledList[_currIndex % _shuffledList.Count()];
            _currIndex++;
            return result;
        }

        private List<int> shuffle(List<int> listToShuffle)
        {
            int n = listToShuffle.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = listToShuffle[k];
                listToShuffle[k] = listToShuffle[n];
                listToShuffle[n] = value;
            }
            return listToShuffle;
        }


    }
}