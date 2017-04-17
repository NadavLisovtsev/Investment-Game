using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InvestmentGame.LearningAgents
{
    public abstract class RegressionAlgoClient
    {
        private  string _serverAddress = ConfigurationManager.AppSettings["LearningServiceAddress"];
      //  private const string _serverAddress = @"http://localhost:1234/";
        private HttpJsonClient _httpClient = new HttpJsonClient(ConfigurationManager.AppSettings["LearningServiceAddress"]);

        private const string _regressionMethodName = "Regression";
        private const string _minRoundsMethodName = "MinRounds";

        public double getPrediction(double money, int roundNum, History hist)
        {
            RegressionRequestData regressionData = new RegressionRequestData(getAlgoName(), money, roundNum, hist);

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