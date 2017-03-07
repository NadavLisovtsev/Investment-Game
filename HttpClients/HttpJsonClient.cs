using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using System.Net;

namespace InvestmentGame.LearningAgents
{
    // Req for Request Data and Res for Response Data
    public class HttpJsonClient
    {
        private string _serverAddress;
        public HttpJsonClient(string address)
        {
            _serverAddress = address;
        }

        public Res Post<Req, Res>(Req data)
        {
            var serializer = new JavaScriptSerializer();

            string jsonData = serializer.Serialize(data);
            string result = sendPost(jsonData);

            return serializer.Deserialize<Res>(result);
        }

        private string sendPost(string data)
        {
            string response;
            using (WebClient client = new WebClient())
            {
                response = client.UploadString(_serverAddress, data);
            }
            return response;
        }
    }
}