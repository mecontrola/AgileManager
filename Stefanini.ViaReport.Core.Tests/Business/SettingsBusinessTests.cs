using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Business
{
    public class SettingsBusinessTests : BaseAsyncMethods
    {
        private readonly ISettingsBusiness settingsBusiness;

        public SettingsBusinessTests()
        {
            var settingsService = SettingsServiceMock.Create();

            settingsBusiness = new SettingsBusiness(settingsService);
        }

        [Fact(DisplayName = "[SettingsBusiness.LoadDataAsync] Deve executar a chamada do service e retornar a informações de configuração.")]
        public async void DeveExecutarLoadDataAsyncRetornarSettings()
        {
            var actual = await settingsBusiness.LoadDataAsync(GetCancellationToken());
            var expected = AppSettingsDtoMock.Create();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[SettingsBusiness.SaveAuthenticationAsync] Deve executar a chamada do service para salvar as informações de usuário do Jira e retornar um boolean de acordo com o processamento.")]
        public async void DeveExecutarSaveAuthenticationAsyncRetornarBool()
        {
            var actual = await settingsBusiness.SaveAuthenticationAsync(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[SettingsBusiness.SavePreferencesAsync] Deve executar a chamada do service para salvar as informações de preferência do usuário e retornar um boolean de acordo com o processamento.")]
        public async void DeveExecutarSavePreferencesAsyncRetornarBool()
        {
            var actual = await settingsBusiness.SavePreferencesAsync(DataMock.BOOL_TRUE, DataMock.BOOL_TRUE, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[SettingsBusiness.SaveFilterDataAsync] Deve executar a chamada do service para salvar as informações dos filtros selecionado pelo usuário e retornar um boolean de acordo com o processamento.")]
        public async void DeveExecutarSaveFilterDataAsyncRetornarBool()
        {
            var actual = await settingsBusiness.SaveFilterDataAsync(AppFilterDtoMock.Create(), GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[SettingsBusiness.IsAuthenticationDataValidAsync] Deve executar a chamada do service para validar se os dados de login do Jira são válidos e retornar um boolean de acordo com o processamento.")]
        public async void DeveExecutarIsAuthenticationDataValidAsyncRetornarBool()
        {
            var actual = await settingsBusiness.IsAuthenticationDataValidAsync(GetCancellationToken());

            actual.Should().BeTrue();
        }
    }
}