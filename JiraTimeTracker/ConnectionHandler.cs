using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Media;

namespace JiraTimeTracker
{
    class ConnectionHandler
    {
        private string login;
        private string password;

        private string url;
        private string apitoken;

        private string query;

        private HttpClient httpClient;


        public ConnectionHandler(string url, string login, string password)
        {
            this.login = login;
            this.password = password;
            this.url = PrepareUrl(url);
            this.apitoken = apitoken;
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

        private string PrepareQuery(string username)
        {
            query = url + "/rest/api/2/search?jql=assignee=" + username;
            return query;
        }

        private string BuildAuthHeader()
        {
            var builtstring = login + ":" + password;
            var plainbytes = Encoding.UTF8.GetBytes(builtstring);
            return Convert.ToBase64String(plainbytes);
        }

        public HttpResponseMessage GetAssignedIssuesForUser(string username)
        {
            PrepareQuery(username);
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(query).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " | Please check your URL for typos");
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
                    SystemSounds.Asterisk.Play();
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + " | Please check your URL for typos");
                return false;
            }
        }
    }
}
