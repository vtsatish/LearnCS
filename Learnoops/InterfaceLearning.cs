using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Learnoops
{
    public interface ILearnClient
    {
        void prepareClient(String clientType);
        void executeClient(String callType);
        ClientClass getClient();
    }

    public class ClientClass
    {
        public String requestUri;
        public ClientClass()
        {
            requestUri = "Default";
        }
    }

    class RESTClient : ILearnClient
    {
        public ClientClass objClient;
        public RESTClient()
        {
            objClient = new ClientClass();
        }
        public void prepareClient(String clientType)
        {
            objClient.requestUri = objClient.requestUri + clientType;
        }
        public void executeClient(String callType)
        {
            objClient.requestUri = objClient.requestUri + callType;
        }
        public ClientClass getClient()
        {
            return objClient;
        }
    }
}
