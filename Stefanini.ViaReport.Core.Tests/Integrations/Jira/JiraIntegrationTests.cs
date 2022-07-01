using FluentAssertions;
using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Exceptions;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Stefanini.ViaReport.Core.Tests.Mocks.Integrations.Jira;
using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute.StatusCategory;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira
{
    [TestCaseOrderer("Xunit.FactPriorityOrderer", "RunCacheTestsOrder")]
    public class JiraIntegrationTests : BaseJiraApiTests
    {
        private const string FOLDER_CACHE = "caches";
        private const string JSON_FILE_NAME = "statuscategory.get.all.json";

        private readonly JiraIntegrationMock service;

        public JiraIntegrationTests()
            : base()
        {
            ConfigureStatusCategoryGetAll();
            ConfigureExceptionApi();

            service = new JiraIntegrationMock(GetConfiguration());
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraAuthenticationException quando o status da requisição retornada for 401.")]
        public async Task DeveGerarJiraAuthenticationExceptionQuandoStatus401()
        {
            var action = () => service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, HttpStatusCode.Unauthorized, GetCancellationToken());
            await action.Should().ThrowAsync<JiraAuthenticationException>();
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraForbiddenException quando o status da requisição retornada for 403.")]
        public async Task DeveGerarJiraForbiddenExceptionQuandoStatus403()
        {
            var action = () => service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, HttpStatusCode.Forbidden, GetCancellationToken());
            await action.Should().ThrowAsync<JiraForbiddenException>();
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraException quando o status da requisição retornada for 408.")]
        public async Task DeveGerarJiraExceptionQuandoStatus409()
        {
            var action = () => service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, HttpStatusCode.RequestTimeout, GetCancellationToken());
            await action.Should().ThrowAsync<JiraException>();
        }

        [FactPriority(5)]
        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve carregar as informações do cache quando a idade do arquivo estiver dentro do tempo limite.")]
        public async Task DeveCarregarCacheQuandoDentroTempoConfiguracao()
        {
            var cacheFilename = GetCacheFilename();

            CreateCacheFile(cacheFilename);

            var expected = StatusCategoryDtoMock.CreateList();
            var actual = await service.Execute<StatusCategoryDto[]>(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, route.GET_ALL, GetCancellationToken());

            actual.Should().NotBeEmpty();
            actual.Should().BeEquivalentTo(expected);

            RemoveCacheFile(cacheFilename);
        }

        private string GetCacheFilename()
        {
            var configuration = GetConfiguration();
            var url = $"{configuration.Path}{route.GET_ALL}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_CACHE);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return Path.Combine(path, $"{url.ToMD5()}.cache");
        }

        private static void CreateCacheFile(string filename)
        {
            var json = ApiUtilMockHelper.ReadJsonFile(JSON_FILE_NAME);
            File.WriteAllText(filename, json);
        }

        private static void RemoveCacheFile(string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
        }
    }
}