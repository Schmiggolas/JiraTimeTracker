using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Media;
using Newtonsoft;

namespace JiraTimeTracker
{
    class ConnectionHandler
    {
        private string login;
        private string password;

        private string url;

        private string query;

        private HttpClient httpClient;
        private CConsole cConsole;


        public ConnectionHandler(string url, string login, string password,CConsole cConsole)
        {
            this.login = login;
            this.password = password;
            this.url = PrepareUrl(url);
            CreateHttpClient();
            if(this.cConsole == null)
            {
                this.cConsole = cConsole;
            }
        }

        public void UpdateVariables(string url, string login, string password)
        {
            this.login = login;
            this.password = password;
            this.url = PrepareUrl(url);
            CreateHttpClient();
        }

        private void CreateHttpClient()
        {
            try
            {
                if (httpClient != null) return;
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", BuildAuthHeader());
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " | Please check your URL for typos");
            }
        }

        private string PrepareUrl(string url)
        {
            if (url.StartsWith("http://"))
            {
                return url;
            }
            else if (url.StartsWith("https://"))
            {
                return "http://" + url.Substring(8);
            }
            else
            {
                return "http://" + url;
            }
        }

        private string PrepareQuery(string username, string projectKey)
        {
            query = url + "/rest/api/2/search?jql=project=" + projectKey + "&assignee=" + username + "&maxResults=1000";

            return query;
        }

        private string BuildAuthHeader()
        {
            var builtstring = login + ":" + password;
            var plainbytes = Encoding.UTF8.GetBytes(builtstring);
            return Convert.ToBase64String(plainbytes);
        }

        public string GetAssignedIssuesForUser(string username, string projectKey)
        {
            PrepareQuery(username, projectKey);
            try
            {
                var response = httpClient.GetAsync(query).Result;
                if (response.IsSuccessStatusCode)
                { 
                    string result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                cConsole.Write(e.Message + " | Please check your URL for typos");
                return null;
            }
        }

        public bool TestConnection()
        {
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                cConsole.Write(e.Message + " | Please check your URL for typos");
                return false;
            }
        }
        
    }
}
