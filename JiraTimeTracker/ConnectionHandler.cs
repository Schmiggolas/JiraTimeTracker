using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JiraTimeTracker
{
    class ConnectionHandler
    {
        private string username;
        private string password;

        private string url;
        private string apitoken;

        private HttpClient httpClient;


        public ConnectionHandler(string url, string apitoken, string username, string password)
        {
            this.username = username;
            this.password = password;
            this.url = url;
            this.apitoken = apitoken;
        }

        private void CreateHttpClient()
        {
            if (httpClient != null) return;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string BuildAuthHeader()
        {
            var builtstring = username + ":" + password;
            var plainbytes = Encoding.UTF8.GetBytes(builtstring);
            return Convert.ToBase64String(plainbytes);
        }

        public bool TestConnection()
        {
            HttpResponseMessage response = httpClient.GetAsync()
        }

    }
}
