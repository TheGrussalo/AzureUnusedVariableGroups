using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class VariableGroupsCreatedBy
{
    public string displayName { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
}

public class VariableGroupsModifiedBy
{
    public string displayName { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
}

class VariableGroups
{
    public int Count { get; set; }
    public List<VariableGroupsValue> value { get; set; }
}
public class VariableGroupsValue
{
    [JsonProperty("Variables")]
    public Dictionary<string, object> Variables { get; set; }
    public int id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public VariableGroupsCreatedBy createdBy { get; set; }
    public DateTime createdOn { get; set; }
    public VariableGroupsModifiedBy modifiedBy { get; set; }
    public DateTime modifiedOn { get; set; }
    public bool isShared { get; set; }
    public object variableGroupProjectReferences { get; set; }
}