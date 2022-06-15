using FluentAssertions;
using Stefanini.ViaReport.Core.Builders.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Synchronizers;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Builders.Dtos
{
    public class IssueConfigurationSynchronizerDtoBuilderTests
    {
        [Fact(DisplayName = "[IssueConfigurationSynchronizerDtoBuilder.ToBuild] Deve criar a entidade com os dados informados.")]
        public void DeveCriarEntidadeComValoresDefinidos()
        {
            var expected = IssueConfigurationSynchronizerDtoMock.Create();
            var actual = IssueConfigurationSynchronizerDtoBuilder.GetInstance()
                                                                 .AddSettings(AppSettingsDtoMock.Create())
                                                                 .AddProjects(DataMock.PROJECTS)
                                                                 .ToBuild();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}