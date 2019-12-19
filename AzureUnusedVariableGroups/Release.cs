using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReleaseDefinitionDetails
{
    public int id { get; set; }
    public object projectReference { get; set; }
    public Dictionary<string, object> _links { get; set; }
}

public class LastReleaseCreatedBy
{
    public string displayName { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
}

public class LastRelease
{
    public int id { get; set; }
    public string name { get; set; }
    public List<object> artifacts { get; set; }
    public Dictionary<string, object> _links { get; set; }
    public string description { get; set; }
    public ReleaseDefinitionDetails releaseDefinition { get; set; }
    public DateTime createdOn { get; set; }
    public LastReleaseCreatedBy createdBy { get; set; }
}

public class Env
{
    public string value { get; set; }
}

public class ReleaseVariables
{
    public Env env { get; set; }
}

public class Owner
{
    public string displayName { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
}

public class EnvironmentVariables
{
}

public class Approval
{
    public int rank { get; set; }
    public bool isAutomated { get; set; }
    public bool isNotificationOn { get; set; }
    public int id { get; set; }
}

public class ApprovalOptions
{
    public object requiredApproverCount { get; set; }
    public bool releaseCreatorCanBeApprover { get; set; }
    public bool autoTriggeredAndPreviousEnvironmentApprovedCanBeSkipped { get; set; }
    public bool enforceIdentityRevalidation { get; set; }
    public int timeoutInMinutes { get; set; }
    public string executionOrder { get; set; }
}

public class PreDeployApprovals
{
    public List<Approval> approvals { get; set; }
    public ApprovalOptions approvalOptions { get; set; }
}

public class DeployStep
{
    public int id { get; set; }
}

public class PostDeployApprovals
{
    public List<Approval> approvals { get; set; }
    public ApprovalOptions approvalOptions { get; set; }
}

public class ParallelExecution
{
    public string parallelExecutionType { get; set; }
}

public class DownloadInput
{
    public string alias { get; set; }
    public string artifactType { get; set; }
    public string artifactDownloadMode { get; set; }
    public List<string> artifactItems { get; set; }
}

public class ArtifactsDownloadInput
{
    public List<DownloadInput> downloadInputs { get; set; }
}

public class OverrideInputs
{
}

public class DeploymentInput
{
    public ParallelExecution parallelExecution { get; set; }
    public object agentSpecification { get; set; }
    public bool skipArtifactsDownload { get; set; }
    public ArtifactsDownloadInput artifactsDownloadInput { get; set; }
    public int queueId { get; set; }
    public List<object> demands { get; set; }
    public bool enableAccessToken { get; set; }
    public int timeoutInMinutes { get; set; }
    public int jobCancelTimeoutInMinutes { get; set; }
    public string condition { get; set; }
    public OverrideInputs overrideInputs { get; set; }
}

public class Environment2
{
}

public class OverrideInputs2
{
}

public class Inputs
{
    public string rootDirectory { get; set; }
    public string targetFiles { get; set; }
    public string encoding { get; set; }
    public string writeBOM { get; set; }
    public string actionOnMissing { get; set; }
    public string keepToken { get; set; }
    public string tokenPrefix { get; set; }
    public string tokenSuffix { get; set; }
    public string emptyValue { get; set; }
    public string escapeChar { get; set; }
    public string charsToEscape { get; set; }
    public string filename { get; set; }
    public string arguments { get; set; }
    public string workingFolder { get; set; }
    public string failOnStandardError { get; set; }
    public string SourceFolder { get; set; }
    public string Contents { get; set; }
    public string RemoveSourceFolder { get; set; }
}

public class WorkflowTask
{
    public Environment2 environment { get; set; }
    public string taskId { get; set; }
    public string version { get; set; }
    public string name { get; set; }
    public string refName { get; set; }
    public bool enabled { get; set; }
    public bool alwaysRun { get; set; }
    public bool continueOnError { get; set; }
    public int timeoutInMinutes { get; set; }
    public string definitionType { get; set; }
    public OverrideInputs2 overrideInputs { get; set; }
    public string condition { get; set; }
    public Inputs inputs { get; set; }
}

public class DeployPhase
{
    public DeploymentInput deploymentInput { get; set; }
    public int rank { get; set; }
    public string phaseType { get; set; }
    public string name { get; set; }
    public object refName { get; set; }
    public List<WorkflowTask> workflowTasks { get; set; }
}

public class EnvironmentOptions
{
    public string emailNotificationType { get; set; }
    public string emailRecipients { get; set; }
    public bool skipArtifactsDownload { get; set; }
    public int timeoutInMinutes { get; set; }
    public bool enableAccessToken { get; set; }
    public bool publishDeploymentStatus { get; set; }
    public bool badgeEnabled { get; set; }
    public bool autoLinkWorkItems { get; set; }
    public bool pullRequestDeploymentEnabled { get; set; }
}

public class ExecutionPolicy
{
    public int concurrencyCount { get; set; }
    public int queueDepthCount { get; set; }
}

public class CurrentRelease
{
    public int id { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
}

public class RetentionPolicy
{
    public int daysToKeep { get; set; }
    public int releasesToKeep { get; set; }
    public bool retainBuild { get; set; }
}

public class ProcessParameters
{
}

public class DeploymentGates
{
    public int id { get; set; }
    public object gatesOptions { get; set; }
    public List<object> gates { get; set; }
}

public class EnvironmentOwner
{
    public string displayName { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
    public string imageUrl { get; set; }
    public string descriptor { get; set; }
}
public class Environment
{
    public int id { get; set; }
    public string name { get; set; }
    public int rank { get; set; }
    public EnvironmentOwner owner { get; set; }
    public EnvironmentVariables variables { get; set; }
    public List<int> variableGroups { get; set; }
    public PreDeployApprovals preDeployApprovals { get; set; }
    public DeployStep deployStep { get; set; }
    public PostDeployApprovals postDeployApprovals { get; set; }
    public List<DeployPhase> deployPhases { get; set; }
    public EnvironmentOptions environmentOptions { get; set; }
    public List<object> demands { get; set; }
    public List<object> conditions { get; set; }
    public ExecutionPolicy executionPolicy { get; set; }
    public List<object> schedules { get; set; }
    public CurrentRelease currentRelease { get; set; }
    public RetentionPolicy retentionPolicy { get; set; }
    public ProcessParameters processParameters { get; set; }
    public DeploymentGates preDeploymentGates { get; set; }
    public DeploymentGates postDeploymentGates { get; set; }
    public List<object> environmentTriggers { get; set; }
    public string badgeUrl { get; set; }
}

public class IdName
{
    public string id { get; set; }
    public string name { get; set; }
}

public class DefinitionReference
{
    public IdName artifactSourceDefinitionUrl { get; set; }
    public IdName defaultVersionBranch { get; set; }
    public IdName defaultVersionSpecific { get; set; }
    public IdName defaultVersionTags { get; set; }
    public IdName defaultVersionType { get; set; }
    public IdName definition { get; set; }
    public IdName definitions { get; set; }
    public IdName IsMultiDefinitionType { get; set; }
    public IdName project { get; set; }
    public IdName repository { get; set; }
}

public class Artifact
{
    public string sourceId { get; set; }
    public string type { get; set; }
    public string alias { get; set; }
    public DefinitionReference definitionReference { get; set; }
    public bool isPrimary { get; set; }
    public bool isRetained { get; set; }
}

public class Trigger
{
    public string artifactAlias { get; set; }
    public List<object> triggerConditions { get; set; }
    public string triggerType { get; set; }
}

//public class Properties2
//{
//    //public string DefinitionCreationSource { get; set; }
//    public string IntegrateJiraWorkItems { get; set; }
//    public string IntegrateBoardsWorkItems { get; set; }
//}

public class ReleaseCreatedBy
{
    public string displayName { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
}

public class ReleaseModifiedBy
{
    public string displayName { get; set; }
    public string id { get; set; }
    public string uniqueName { get; set; }
}
public class Release
{
    public string source { get; set; }
    public int revision { get; set; }
    public object description { get; set; }
    public ReleaseCreatedBy createdBy { get; set; }
    public DateTime createdOn { get; set; }
    public ReleaseModifiedBy modifiedBy { get; set; }
    public DateTime modifiedOn { get; set; }
    public bool isDeleted { get; set; }
    public LastRelease lastRelease { get; set; }
    public ReleaseVariables variables { get; set; }
    public List<int> variableGroups { get; set; }
    public List<Environment> environments { get; set; }
    public List<Artifact> artifacts { get; set; }
    public List<Trigger> triggers { get; set; }
    public string releaseNameFormat { get; set; }
    public List<object> tags { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string path { get; set; }
    public object projectReference { get; set; }
    public string url { get; set; }
    public Dictionary<string, object> _links { get; set; }
}