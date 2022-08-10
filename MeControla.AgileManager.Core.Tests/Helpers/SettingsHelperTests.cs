using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks.Entities.Settings;
using MeControla.AgileManager.Data.Dtos.Settings;
using MeControla.Kernel.Extensions;
using MeControla.Kernel.Settings;
using NSubstitute;
using System.IO;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
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

            ShouldBe(settings, data);

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

            ShouldBe(settings, data);

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

            ShouldBe(settings, data);

            settings.Data.FilterData.Should().Be(data.FilterData);
            settings.Received(1).SaveSettings();
        }

        private static void ShouldBe(ISettingsManager<AppSettingsDto> actual, AppSettingsDto expected)
        {
            actual.Data.Url.Should().BeEquivalentTo(expected.Url.Base64Encode());
            actual.Data.Username.Should().BeEquivalentTo(expected.Username.Base64Encode());
            actual.Data.Password.Should().BeEquivalentTo(expected.Password.Base64Encode());
            actual.Data.PersistFilter.Should().Be(expected.PersistFilter);
            actual.Data.Cache.Should().Be(expected.Cache);
        }
    }
}