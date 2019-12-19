using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReleaseDefinitions
{
    public int Count { get; set; }
    public List<ReleaseDefinition> value { get; set; }
}

public class Properties
{
}

public class DefinitionCreatedBy
{
    public string displayName { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
}

public class DefinitionModifiedBy
{
    public string displayName { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
}
public class ReleaseDefinition
{
    public string source { get; set; }
    public int revision { get; set; }
    public object description { get; set; }
    public DefinitionCreatedBy createdBy { get; set; }
    public DateTime createdOn { get; set; }
    public DefinitionModifiedBy modifiedBy { get; set; }
    public DateTime modifiedOn { get; set; }
    public bool isDeleted { get; set; }
    public object variableGroups { get; set; }
    public string releaseNameFormat { get; set; }
    public Properties properties { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string path { get; set; }
    public object projectReference { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
}