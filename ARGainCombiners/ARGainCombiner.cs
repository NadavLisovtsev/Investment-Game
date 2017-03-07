using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame
{
    public abstract class ARGainCombiner
    {
        abstract public double combine(double ar, double gain);
    }
}