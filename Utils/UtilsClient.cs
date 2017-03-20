using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


using System.Configuration;
using AsymptoticAverage;namespace InvestmentGame.Utils
{
    public class UtilsClient
    {
    //    private string _zeroMQEndpoint = ConfigurationManager.AppSettings["UtilsEndpoint"];
   //     private ZeroMQCommunicator _communicator = Global.zeroMQCommunicator;
        private AsymptoticAverageClass _avg = new AsymptoticAverageClass();

        public UtilsClient()
        {
            // _communicator = new ZeroMQCommunicator(_zeroMQEndpoint);
        }

        public double CalcAsymptoticAverage(double[] values)
        {
            return _avg.calcAverage(values.ToList());
        }

        public double AddValueToAsymptoticAverage(double val, double average)
        {
            return _avg.addValueToAverage(val, average);
        }

  /*      public double CalcAsymptoticAverage(double[] values)
        {
            UtilsRequestData requestData = new UtilsRequestData();

            requestData.Method = "CalcAsymptoticAverage";
            requestData.Data = values;

            return _communicator.SendRequest<Double, UtilsRequestData>(requestData);
        }

        public double AddValueToAsymptoticAverage(double val, double average)
        {
            double[] values = new double[] {val, average};

            UtilsRequestData requestData = new UtilsRequestData();

            requestData.Method = "CalcAsymptoticAverage";
            requestData.Data = values;

            return _communicator.SendRequest<Double, UtilsRequestData>(requestData);
        }*/


    }
}