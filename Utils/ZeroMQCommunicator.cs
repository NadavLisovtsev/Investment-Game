using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroMQ;
using System.Web.Script.Serialization;

namespace InvestmentGame.Utils
{
    public class ZeroMQCommunicator : IDisposable
    {
        private string _endpoint;
        private ZContext context;
        private ZSocket requester;

        public ZeroMQCommunicator(string endpoint)
        {
            _endpoint = endpoint;
            context = new ZContext();
            requester = new ZSocket(context, ZSocketType.REQ);

        }
        
        public ResponseType SendRequest<ResponseType, RequestType>(RequestType requestData)
        {

            // Create
  //          using (var context = new ZContext())
  //          using (var requester = new ZSocket(context, ZSocketType.REQ))
  //          {
                // Connect
                requester.Connect(_endpoint);

                var serializer = new JavaScriptSerializer();
                string requestJson = serializer.Serialize(requestData);

                // Send Data
                requester.Send(new ZFrame(requestJson));

                // Receive Result
                using (ZFrame reply = requester.ReceiveFrame())
                {
                    string strResult = reply.ReadString();
                    return  serializer.Deserialize<ResponseType>(strResult);
                }
//            }
        }
    
        public void Dispose()
        {
            requester.Dispose();
            context.Dispose();
        }
    }
}