using FluentAssertions;
using MeControla.AgileManager.Core.Builders.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Entities.Settings;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Builders.Dtos
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