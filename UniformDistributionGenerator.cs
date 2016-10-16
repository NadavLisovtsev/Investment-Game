using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public class UniformDistributionGenerator
    {
        private int[] buckets;
        private int min;
        private int max;

        public UniformDistributionGenerator(int mn, int mx) //include both!!
        {
            min = mn;
            max = mx;

            buckets = new int[max - min + 1];
        }

        public int getRandomNum()
        {
            List<int> minValIndixes = new List<int>();
            int minVal = buckets.Min();


            for(int i = 0; i < buckets.Length; i++)
            {
                if(buckets[i] == minVal)
                {
                    minValIndixes.Add(i);
                }
            }

            Random r = new Random();

            int resultNum = minValIndixes[r.Next(minValIndixes.Count)];

            buckets[resultNum]++;

            return resultNum + min;          
        }
    }
}