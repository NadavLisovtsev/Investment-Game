using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public class RequestData<T>
    {
        public string Method;
        public T Data;

        public RequestData(string methodName, T data)
        {
            Method = methodName;
            Data = data;
        }

    }
}