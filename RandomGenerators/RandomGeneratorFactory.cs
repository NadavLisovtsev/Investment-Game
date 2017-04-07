using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.RandomGenerators
{
    public class RandomGeneratorFactory
    {
        private Dictionary<string, Type> _generatorsDict;

        public RandomGeneratorFactory()
        {
            _generatorsDict = new Dictionary<string, Type>();

            _generatorsDict.Add("Uniform", Type.GetType("InvestmentGame.UniformDistributionGenerator"));
            _generatorsDict.Add("Shuffle", Type.GetType("InvestmentGame.RandomGenerators.ListShuffleGenerator"));
        }

        public IRandomGenerator CreateRandomGenerator(string name, int mn, int mx)
        {
            IRandomGenerator generator = (IRandomGenerator)Activator.CreateInstance(_generatorsDict[name], new object[] { mn, mx });

            return generator;

        }
    }
}