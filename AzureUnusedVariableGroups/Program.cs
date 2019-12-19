using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AzureUnusedVariableGroups
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await GetUnusedVariableGroups();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static async Task GetUnusedVariableGroups()
        {
            VariableGroups vGroups = await GetVariableGroupsAsync();
            ReleaseDefinitions releaseDefinitions = await GetReleaseDefinitionsAsync();
            List<VariableGroupsValue> groups = vGroups.value;
            List<int> usedGroups = new List<int>();

            foreach (ReleaseDefinition rDef in releaseDefinitions.value)
            {
                Release release = await GetRelease(rDef.id);

                foreach (int variablegroupId in release.variableGroups)
                {
                    var g = groups.Find(x => x.id == variablegroupId);
                    if (g == null)
                    {
                        Console.WriteLine(string.Format("{0} is referencing a deleted variable group (id-{1})", rDef.name, variablegroupId));
                    }
                    else
                    {
                        usedGroups.Add(variablegroupId);
                    }
                }
                foreach (Environment environment in release.environments)
                {
                    foreach (int variablegroupId in environment.variableGroups)
                    {
                        var g = groups.Find(x => x.id == variablegroupId);
                        if (g == null)
                        {
                            Console.WriteLine(string.Format("{0} is referencing a deleted variable group (id-{1})", rDef.name, variablegroupId));
                        }
                        else
                        {
                            usedGroups.Add(variablegroupId);
                        }
                    }
                }
            }

            BuildDefinitions buildDefinitions = await GetBuildDefinitionsAsync();
            foreach (var buildDefinition in buildDefinitions.value)
            {
                Build build = await GetBuild(buildDefinition.id);
                if (build.variableGroups != null)
                {
                    foreach (VariableGroup variablegroup in build.variableGroups)
                    {
                        var g = groups.Find(x => x.id == variablegroup.id);
                        if (g == null)
                        {
                            Console.WriteLine(string.Format("{0} is referencing a deleted variable group (id-{1})", buildDefinition.name, variablegroup.id));
                        }
                        else
                        {
                            usedGroups.Add(variablegroup.id);
                        }
                    }
                }
            }

            bool used;
            foreach (var variableGroup in vGroups.value)
            {
                used = false;
                foreach (var usedGroup in usedGroups)
                {
                    if (variableGroup.id == usedGroup)
                    {
                        used = true;
                    }
                }
                if (used == false)
                {
                    Console.WriteLine(String.Format("'{0}' is not used - id {1}", variableGroup.name, variableGroup.id));
                }
            }
        }

        public static async Task<Release> GetRelease(int id)
        {
            try
            {
                var jsonText = await ExecuteJsonAsync(String.Format("https://vsrm.dev.azure.com/{0}/{1}/_apis/Release/definitions/{2}", Properties.Settings.Default.Organisation, Properties.Settings.Default.ProjectName, id));

                Release release = JsonConvert.DeserializeObject<Release>(jsonText);
                return release;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public static async Task<Build> GetBuild(int id)
        {
            try
            {
                var jsonText = await ExecuteJsonAsync(String.Format("https://dev.azure.com/{0}/{1}/_apis/build/Definitions/{2}", Properties.Settings.Default.Organisation, Properties.Settings.Default.ProjectName, id));

                Build build = JsonConvert.DeserializeObject<Build>(jsonText);
                return build;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public static async Task<VariableGroups> GetVariableGroupsAsync()
        {
            try
            {
                var jsonText = await ExecuteJsonAsync(string.Format("https://dev.azure.com/{0}/{1}/_apis/distributedtask/variablegroups", Properties.Settings.Default.Organisation, Properties.Settings.Default.ProjectName));

                VariableGroups vGroups = JsonConvert.DeserializeObject<VariableGroups>(jsonText);
                return vGroups;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public static async Task<ReleaseDefinitions> GetReleaseDefinitionsAsync()
        {
            try
            {
                var jsonText = await ExecuteJsonAsync(String.Format("https://vsrm.dev.azure.com/{0}/{1}/_apis/release/definitions", Properties.Settings.Default.Organisation, Properties.Settings.Default.ProjectName));

                ReleaseDefinitions rDef = JsonConvert.DeserializeObject<ReleaseDefinitions>(jsonText);
                return rDef;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public static async Task<BuildDefinitions> GetBuildDefinitionsAsync()
        {
            try
            {
                var jsonText = await ExecuteJsonAsync(String.Format("https://dev.azure.com/{0}/{1}/_apis/build/definitions", Properties.Settings.Default.Organisation, Properties.Settings.Default.ProjectName));

                BuildDefinitions buildDefinitions = JsonConvert.DeserializeObject<BuildDefinitions>(jsonText);
                return buildDefinitions ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private static async Task<string> ExecuteJsonAsync(string Url)
        {
            var personalaccesstoken = Properties.Settings.Default.PersonalAccessToken;

            var handler = new HttpClientHandler();
            handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", personalaccesstoken))));

                using (HttpResponseMessage response = await client.GetAsync(Url))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
        }

        public static async Task GetProjects()
        {
            var jsonText = await ExecuteJsonAsync(String.Format(String.Format("https://dev.azure.com/{0}/{1}/_apis/distributedtask/variablegroups", Properties.Settings.Default.Organisation, Properties.Settings.Default.ProjectName)));
            Console.WriteLine(jsonText);
        }
    }
}
