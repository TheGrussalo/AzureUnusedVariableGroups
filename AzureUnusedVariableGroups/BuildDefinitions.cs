using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BuildDefinitions
{
public int Count { get; set; }
    public List<BuildDefinition> value { get; set; }
}
public class AuthoredBy
{
    public string displayName { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
}

public class Pool
{
    public int id { get; set; }
    public string name { get; set; }
    public bool isHosted { get; set; }
}

public class Queue
{
    public Dictionary<string, object> _links { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public Pool pool { get; set; }
}
public class BuildDefinitionProject
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string state { get; set; }
    public int revision { get; set; }
    public string visibility { get; set; }
    public DateTime lastUpdateTime { get; set; }
}
public class BuildDefinition
{
    public Dictionary<string, object> _links { get; set; }
    public string quality { get; set; }
    public AuthoredBy authoredBy { get; set; }
    public List<object> drafts { get; set; }
    public Queue queue { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public string uri { get; set; }
    public string path { get; set; }
    public string type { get; set; }
    public string queueStatus { get; set; }
    public int revision { get; set; }
    public DateTime createdDate { get; set; }
    public BuildDefinitionProject project { get; set; }
}