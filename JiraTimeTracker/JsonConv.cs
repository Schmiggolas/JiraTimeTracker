using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JiraTimeTracker
{
    public class Assignee
    {
        public string name { get; set; }
        public string key { get; set; }
    }

    public class Fields
    {
        public int? timespent { get; set; }
        public Assignee assignee { get; set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class IssuesRoot
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }

    public class Item
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
    }

    public class Users
    {
        public int size { get; set; }
        public List<Item> items { get; set; }
    }

    public class UserRoot
    {
    public string name { get; set; }
    public string self { get; set; }
    public Users users { get; set; }
    public string expand { get; set; }
    }

    public class Config
    {
        public string url { get; set; }
        public string login { get; set; }
    }

class JsonConv
    {
        public IssuesRoot DecodeJsonToIssuesRoot(string jsonstr)
        {
            return JsonConvert.DeserializeObject<IssuesRoot>(jsonstr);
        }

        public UserRoot DecodeJsonToUserRoot(string jsonstr)
        {
            return JsonConvert.DeserializeObject<UserRoot>(jsonstr);
        }

        public Config DecodeJsonToConfig(string jsonstr)
        {
            return JsonConvert.DeserializeObject<Config>(jsonstr);
        }
    }
}
