using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public abstract class RegressionAlgoClient
    {
        private const string _serverAddress = @"http://localhost:1234/";
        private HttpJsonClient _httpClient = new HttpJsonClient(_serverAddress);

        private const string _regressionMethodName = "Regression";
        private const string _minRoundsMethodName = "MinRounds";

        public double getPrediction(List<double> ARs, List<double> gains)
        {
            RegressionRequestData regressionData = new RegressionRequestData(getAlgoName(), ARs, gains);

            RequestData<RegressionRequestData> data = new RequestData<RegressionRequestData>(_regressionMethodName, regressionData);

            RegressionResponseData response = _httpClient.Post<RequestData<RegressionRequestData>, RegressionResponseData>(data);

            return double.Parse(response.Result);
        }

        public int getMinRounds()
        {
            string algoName = getAlgoName();
            var data = new RequestData<MinRoundsRequestsData>(_minRoundsMethodName, new MinRoundsRequestsData(algoName));

            RegressionResponseData response = _httpClient.Post<RequestData<MinRoundsRequestsData>, RegressionResponseData>(data);
            return int.Parse(response.Result);
        }
   
        abstract protected string getAlgoName();
    }
}