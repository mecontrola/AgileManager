using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
{
    public class RecoverDateTimeFirstStatusMatchBacklogHelperTests
    {
        private const string ISSUE_KEY_SEA_217 = "SEA-217";

        private readonly IRecoverDateTimeFirstStatusMatchBacklogHelper helper;

        public RecoverDateTimeFirstStatusMatchBacklogHelperTests()
        {
            helper = new RecoverDateTimeFirstStatusMatchBacklogHelper(new CheckChangelogTypeHelper());
        }

        [Fact(DisplayName = "[RecoverDateTimeFirstStatusMatchBacklogHelper.GetChangelog] Deve retornar a primeira ocorrência de status existente no backlog de uma issue.")]
        public void DeveRetornarPrimeiraStatusListaFornecida()
        {
            var expected = DataMock.DATETIME_CHANGELOG_STATUS;
            var actual = helper.GetDateTime(GetChangelog(), GetStatuses());

            actual.Should().NotBeNull();
            actual.Value.Date.Should().Be(expected.Date);
        }

        [Fact(DisplayName = "[RecoverDateTimeFirstStatusMatchBacklogHelper.GetChangelog] Deve retornar null quando não existerem changelogs na issue.")]
        public void DeveRetornarNullQuandoVazio()
        {
            var actual = helper.GetDateTime(ChangelogDtoMock.CreateEmpty(), GetStatuses());

            actual.Should().BeNull();
        }

        private static IList<string> GetStatuses()
            => StatusDtoMock.CreateListInProgress()
                            .Select(x => x.Id)
                            .ToList();

        private static ChangelogDto GetChangelog()
            => IssueDtoMock.CreateIssueByJson(ISSUE_KEY_SEA_217)
                           .Changelog;
    }
}