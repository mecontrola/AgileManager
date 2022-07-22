using FluentAssertions;
using NSubstitute;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings;
using Stefanini.ViaReport.Core.Tests.Mocks.Helpers;
using Stefanini.ViaReport.Data.Dtos.Settings;
using System.Collections.Generic;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class SettingsServiceTests : BaseAsyncMethods
    {
        private readonly ISettingsHelper settingsHelper;

        private readonly ISettingsService settingsService;

        public SettingsServiceTests()
        {
            settingsHelper = SettingsHelperMock.Create();

            settingsService = new SettingsService(settingsHelper);
        }

        [Fact(DisplayName = "[SettingsService.LoadDataAsync] Deve carregar as informações de configuração.")]
        public async void DeveCarregarConfiguracoes()
        {
            var actual = await settingsService.LoadDataAsync(GetCancellationToken());
            var expected = AppSettingsDtoMock.Create();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[SettingsService.SavePreferencesAsync] Deve salvar as informações de configuração.")]
        public async void DeveSalvarInformacaoPreferences()
        {
            var expectedPersistFilter = DataMock.BOOL_TRUE;
            var expectedSyncAllData = DataMock.BOOL_TRUE;
            var actual = await settingsService.SavePreferencesAsync(expectedPersistFilter, expectedSyncAllData, GetCancellationToken());

            var data = await settingsService.LoadDataAsync(GetCancellationToken());

            settingsHelper.Received()
                          .Save();

            actual.Should().BeTrue();

            data.PersistFilter.Should().Be(expectedPersistFilter);
            data.SyncAllData.Should().Be(expectedSyncAllData);
        }

        [Fact(DisplayName = "[SettingsService.SaveAuthenticationAsync] Deve salvar as informações de autenticação.")]
        public async void DeveSalvarInformacaoAuthentication()
        {
            var expectedUsername = DataMock.VALUE_DEFAULT_TEXT;
            var expectedPassword = DataMock.VALUE_DEFAULT_TEXT2;
            var actual = await settingsService.SaveAuthenticationAsync(expectedUsername, expectedPassword, GetCancellationToken());

            var data = await settingsService.LoadDataAsync(GetCancellationToken());

            settingsHelper.Received()
                          .Save();

            actual.Should().BeTrue();
            data.Username.Should().Be(expectedUsername);
            data.Password.Should().Be(expectedPassword);
        }

        [Fact(DisplayName = "[SettingsService.SaveFilterDataAsync] Deve salvar as informações selecionadas do filtro.")]
        public async void DeveSalvarInformacaoFilterData()
        {
            var expected = AppFilterDtoMock.Create();
            var actual = await settingsService.SaveFilterDataAsync(expected, GetCancellationToken());

            var data = await settingsService.LoadDataAsync(GetCancellationToken());

            settingsHelper.Received()
                          .Save();

            actual.Should().BeTrue();
            data.FilterData.Should().BeEquivalentTo(expected);
        }

        [Theory(DisplayName = "[SettingsService.IsAuthenticationDataValidAsync] Deve validar se o username e password salvos estão em branco.")]
        [MemberData(nameof(AuthenticationDataValid))]
        public async void DeveValidarInformacoesUsernamePassword(AppSettingsDto appSettingsDto, bool expected)
        {
            settingsHelper.Data.Returns(appSettingsDto);

            var actual = await settingsService.IsAuthenticationDataValidAsync(GetCancellationToken());

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> AuthenticationDataValid()
        {
            yield return new object[] { AppSettingsDtoMock.CreateWithEmptyUsername(), false };
            yield return new object[] { AppSettingsDtoMock.CreateWithEmptyPassword(), false };
            yield return new object[] { AppSettingsDtoMock.CreateWithEmptyUsernameAndPassword(), false };
            yield return new object[] { AppSettingsDtoMock.Create(), true };
        }
    }
}