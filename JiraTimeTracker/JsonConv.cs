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

    public class RootObject
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }

    class JsonConv
    {
        public RootObject DecodeJsonToRootObject(string jsonstr)
        {
            return JsonConvert.DeserializeObject<RootObject>(jsonstr);
        }
    }
}
