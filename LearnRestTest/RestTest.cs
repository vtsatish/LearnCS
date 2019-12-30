using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace LearnRestTest
{
    [Binding]
    public class RestTest : Steps
    {
        private String requestUri;
        private HttpResponseMessage response;
        private HttpClient httpClient;
        private string responseBody;
        private JArray jsonvar;
        public RestTest()
        {
            
        }

        [Given(@"I have client ready")]
        public void GivenIHaveClientReady()
        {
            requestUri = "http://dummy.restapiexample.com/";
            httpClient = new HttpClient();
        }

        [When(@"I execute the client")]
        public async Task WhenIExecuteTheClient()
        {
            string employees = "api/v1/employees";  
            httpClient.BaseAddress = new Uri(requestUri);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await httpClient.GetAsync(employees);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
        }

        [Then(@"the response should be successful")]
        public void ThenTheResponseShouldBeSuccessful()
        {

            bool respExists;
            if (responseBody.Length > 0)
            {
                respExists = true;
            }
            else
            {
                respExists = false;
            }
            Xunit.Assert.True(respExists);
        }

        [Then(@"the response should contain employee id (.*)")]
        public void ThenTheResponseShouldContainEmployeeId(int p0)
        {
            ArrayList myList = new ArrayList();
            jsonvar = JArray.Parse(responseBody);
            Xunit.Assert.True(jsonvar.Count > 0);
            foreach(JObject item in jsonvar)
            {
                myList.Add(item.GetValue("id").ToString());
            }
            Xunit.Assert.Equal("1", myList[0]);
        }


    }
}
