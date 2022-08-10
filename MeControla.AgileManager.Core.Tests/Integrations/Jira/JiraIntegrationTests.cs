using FluentAssertions;
using MeControla.AgileManager.Core.Exceptions;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Integrations.Jira;
using MeControla.AgileManager.Core.Tests.TestUtils.Helpers;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.Kernel.Extensions;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.StatusCategory;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira
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

            service = new JiraIntegrationMock(GetSettings());
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraAuthenticationException quando o status da requisição retornada for 401.")]
        public async Task DeveGerarJiraAuthenticationExceptionQuandoStatus401()
        {
            var action = () => service.Execute(HttpStatusCode.Unauthorized, GetCancellationToken());
            await action.Should().ThrowAsync<JiraAuthenticationException>();
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraForbiddenException quando o status da requisição retornada for 403.")]
        public async Task DeveGerarJiraForbiddenExceptionQuandoStatus403()
        {
            var action = () => service.Execute(HttpStatusCode.Forbidden, GetCancellationToken());
            await action.Should().ThrowAsync<JiraForbiddenException>();
        }

        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve gerar a exceção JiraException quando o status da requisição retornada for 408.")]
        public async Task DeveGerarJiraExceptionQuandoStatus409()
        {
            var action = () => service.Execute(HttpStatusCode.RequestTimeout, GetCancellationToken());
            await action.Should().ThrowAsync<JiraException>();
        }

        [FactPriority(5)]
        [Fact(DisplayName = "[BaseJiraIntegration.GetResponse] Deve carregar as informações do cache quando a idade do arquivo estiver dentro do tempo limite.")]
        public async Task DeveCarregarCacheQuandoDentroTempoConfiguracao()
        {
            var cacheFilename = GetCacheFilename();

            CreateCacheFile(cacheFilename);

            var expected = StatusCategoryDtoMock.CreateList();
            var actual = await service.Execute<StatusCategoryDto[]>(route.GET_ALL, GetCancellationToken());

            actual.Should().NotBeEmpty();
            actual.Should().BeEquivalentTo(expected);

            RemoveCacheFile(cacheFilename);
        }

        private string GetCacheFilename()
        {
            var configuration = GetSettings().GetJiraConfiguration();
            var url = $"{configuration.Url}{route.GET_ALL}";
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