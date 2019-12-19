using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OptionInputs
{
    public string workItemType { get; set; }
    public string assignToRequestor { get; set; }
    public string additionalFields { get; set; }
}
public class OptionDefinition
{
    public string id { get; set; }
}

public class Option
{
    public bool enabled { get; set; }
    public OptionDefinition definition { get; set; }
    public OptionInputs inputs { get; set; }
}

public class TriggerProject
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

public class TriggerDefinition
{
    public int id { get; set; }
    public string url { get; set; }
    public string path { get; set; }
    public string queueStatus { get; set; }
    public TriggerProject project { get; set; }
}

public class BuildTrigger
{
    public TriggerDefinition definition { get; set; }
    public bool requiresSuccessfulBuild { get; set; }
    public List<string> branchFilters { get; set; }
    public string triggerType { get; set; }
}

public class SystemDebug
{
    public string value { get; set; }
    public bool allowOverride { get; set; }
}

public class BuildVariables
{
    [JsonProperty("system.debug")]
    public SystemDebug systemDebug { get; set; }
}

public class VariableGroup
{
    [JsonProperty("variables")]
    public Dictionary<string, object> variables { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int id { get; set; }
}

public class BuildEnvironment
{
}

public class StepTask
{
    public string id { get; set; }
    public string versionSpec { get; set; }
    public string definitionType { get; set; }
}

public class StepInputs
{
    public string script { get; set; }
    public string workingDirectory { get; set; }
    public string failOnStderr { get; set; }
}

public class Step
{
    public BuildEnvironment environment { get; set; }
    public bool enabled { get; set; }
    public bool continueOnError { get; set; }
    public bool alwaysRun { get; set; }
    public string displayName { get; set; }
    public int timeoutInMinutes { get; set; }
    public string condition { get; set; }
    public StepTask task { get; set; }
    public StepInputs inputs { get; set; }
}

public class ExecutionOptions
{
    public int type { get; set; }
}

public class Target
{
    public ExecutionOptions executionOptions { get; set; }
    public bool allowScriptsAuthAccessOption { get; set; }
    public int type { get; set; }
}

public class Phase
{
    public List<Step> steps { get; set; }
    public string name { get; set; }
    public string refName { get; set; }
    public string condition { get; set; }
    public Target target { get; set; }
    public string jobAuthorizationScope { get; set; }
}

public class Process
{
    public List<Phase> phases { get; set; }
    public int type { get; set; }
}

public class RepositoryProperties
{
    public string cleanOptions { get; set; }
    public string labelSources { get; set; }
    public string labelSourcesFormat { get; set; }
    public string reportBuildStatus { get; set; }
    public string gitLfsSupport { get; set; }
    public string skipSyncSource { get; set; }
    public string checkoutNestedSubmodules { get; set; }
    public string fetchDepth { get; set; }
}

public class BuildRepository
{
    public RepositoryProperties properties { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public string defaultBranch { get; set; }
    public string clean { get; set; }
    public bool checkoutSubmodules { get; set; }
}

public class BuildProcessParameters
{
}

public class BuildAuthoredBy
{
    public string displayName { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
}

public class QueuePool
{
    public int id { get; set; }
    public string name { get; set; }
}

public class BuildQueue
{
    public Dictionary<string, object> _links { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public QueuePool pool { get; set; }
}

public class BuildProject
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

public class BuildProperties
{
}


public class Build
{
    public List<Option> options { get; set; }
    public List<BuildTrigger> triggers { get; set; }
    public BuildVariables variables { get; set; }
    public List<VariableGroup> variableGroups { get; set; }
    public BuildProperties properties { get; set; }
    public List<object> tags { get; set; }
    public Dictionary<string, object> _links { get; set; }
    public string jobAuthorizationScope { get; set; }
    public int jobTimeoutInMinutes { get; set; }
    public int jobCancelTimeoutInMinutes { get; set; }
    public Process process { get; set; }
    public BuildRepository repository { get; set; }
    public BuildProcessParameters processParameters { get; set; }
    public string quality { get; set; }
    public BuildAuthoredBy authoredBy { get; set; }
    public List<object> drafts { get; set; }
    public BuildQueue queue { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public string uri { get; set; }
    public string path { get; set; }
    public string type { get; set; }
    public string queueStatus { get; set; }
    public int revision { get; set; }
    public DateTime createdDate { get; set; }
    public BuildProject project { get; set; }
}