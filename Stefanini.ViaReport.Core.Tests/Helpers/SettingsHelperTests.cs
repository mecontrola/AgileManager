using FluentAssertions;
using NSubstitute;
using Stefanini.Core.Extensions;
using Stefanini.Core.Settings;
using Stefanini.ViaReport.Core.Data.Dto.Settings;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings;
using System.IO;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class SettingsHelperTests
    {
        private static readonly string FILEPATH = Path.Combine(Directory.GetCurrentDirectory(), "usersettings.json");

        private readonly ISettingsManager<AppSettingsDto> settings;

        public SettingsHelperTests()
        {
            settings = Substitute.For<ISettingsManager<AppSettingsDto>>();
            settings.Data.Returns(AppSettingsDtoMock.CreateEmpty());
        }

        [Fact(DisplayName = "[SettingsHelper.Constructor] Deve gerar o arquivo e salvar com as informações default ao criar instancia do objeto.")]
        public void DeveGerarArquivoSalvarDadosDefault()
        {
            var data = AppSettingsDtoMock.CreateEmpty();
            var settingsHelper = new SettingsHelper();

            settingsHelper.Data.Username.Should().BeEquivalentTo(data.Username);
            settingsHelper.Data.Password.Should().BeEquivalentTo(data.Password.Base64Encode());
            File.Exists(FILEPATH).Should().BeTrue();

            File.Delete(FILEPATH);
        }

        [Fact(DisplayName = "[SettingsHelper.Save] Deve preencher com as informações e criptografar com Base64 a senha e salvar no arquivo.")]
        public void DevePreencherSalvarDadosArquivo()
        {
            var data = AppSettingsDtoMock.Create();

            var settingsHelper = new SettingsHelper(settings)
            {
                Data = data
            };
            settingsHelper.Save();

            settings.Data.Username.Should().BeEquivalentTo(data.Username);
            settings.Data.Password.Should().BeEquivalentTo(data.Password.Base64Encode());
            settings.Data.PersistFilter.Should().Be(data.PersistFilter);
            settings.Data.FilterData.Should().BeNull();
            settings.Received(1).SaveSettings();
        }

        [Fact(DisplayName = "[SettingsHelper.Save] Deve preencher com as informações e criptografar com Base64 a senha e salvar no arquivo juntamento com as opções de filtro.")]
        public void DevePreencherSalvarDadosArquivoComDadosFiltro()
        {
            var data = AppSettingsDtoMock.CreateWithCacheFilter();

            var settingsHelper = new SettingsHelper(settings)
            {
                Data = data
            };
            settingsHelper.Save();

            settings.Data.Username.Should().BeEquivalentTo(data.Username);
            settings.Data.Password.Should().BeEquivalentTo(data.Password.Base64Encode());
            settings.Data.PersistFilter.Should().Be(data.PersistFilter);
            settings.Data.FilterData.Should().Be(data.FilterData);
            settings.Received(1).SaveSettings();
        }
    }
}