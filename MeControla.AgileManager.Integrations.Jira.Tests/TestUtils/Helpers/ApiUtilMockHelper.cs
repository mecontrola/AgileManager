using MeControla.AgileManager.Integrations.Jira.Converters;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.TestingTools.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MeControla.AgileManager.Integrations.Jira.Tests.TestUtils.Helpers
{
    public class ApiUtilMockHelper : BaseApiUtilMockHelper
    {
        private const string PREFIX_FILE_NAME = "issue.get";
        private const string REGEX_PARAM_KEY_JIRA = "key";
        private const string REGEX_KEY_JIRA = @$"^(.*)issue.get.(?<{REGEX_PARAM_KEY_JIRA}>[A-Z]{{3,}}-[0-9]+).json$";
        private const string FILE_ISSUE_PARAM_KEY = $"{{{REGEX_PARAM_KEY_JIRA}}}";
        private const string FILE_ISSUE_JSON = $"{PREFIX_FILE_NAME}.{FILE_ISSUE_PARAM_KEY}.json";

        public static IssueDto LoadIssueJsonMock(string key)
            => LoadJsonMock<IssueDto>(FILE_ISSUE_JSON.Replace(FILE_ISSUE_PARAM_KEY, key));

        public static T LoadJsonMock<T>(string filename)
            where T : class
            => JsonSerializer.Deserialize<T>(ReadJsonFile(filename), CreateJsonCofiguration());

        private static JsonSerializerOptions CreateJsonCofiguration()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };
            jsonOptions.Converters.Add(new DateTimeJiraConverter());
            return jsonOptions;
        }

        public static IList<string> GetKeyIssues()
            => GetFilenameList().Where(x => x.Contains(PREFIX_FILE_NAME))
                                .Select(x => Regex.Matches(x, REGEX_KEY_JIRA)[0]
                                                  .Groups[REGEX_PARAM_KEY_JIRA]
                                                  .Value)
                                .ToList();
    }
}