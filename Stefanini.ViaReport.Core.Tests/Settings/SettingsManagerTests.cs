using FluentAssertions;
using Stefanini.Core.Settings;
using Stefanini.ViaReport.Core.Data.Dto.Settings;
using Stefanini.ViaReport.Core.Tests.Mocks.Entities.Settings;
using System.IO;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Settings
{
    public class SettingsManagerTests
    {
        private static readonly string FILEPATH = Path.Combine(Directory.GetCurrentDirectory(), FILENAME);

        private const string FILENAME = "settings.test";

        [Fact(DisplayName = "[SettingsManager.LoadSettings] Deve carregar as informações padrões quando não houvem alterações de configuração.")]
        public void DeveCarregarInformacoesPadroesArquivo()
        {
            var settings = new SettingsManager<AppSettingsDto>(FILENAME);

            var actual = settings.LoadSettings();
            var expected = AppSettingsDtoMock.CreateEmpty();

            File.Exists(FILEPATH).Should().BeTrue();

            actual.Should().BeEquivalentTo(expected);

            File.Delete(FILEPATH);
        }

        [Fact(DisplayName = "[SettingsManager.LoadSettings] Deve carregar as informações quando forem salvas as alterações de configuração.")]
        public void DeveCarregarInformacoesAlteradasArquivo()
        {
            var settings = new SettingsManager<AppSettingsDto>(FILENAME)
            {
                Data = AppSettingsDtoMock.Create()
            };
            settings.SaveSettings();

            var actual = settings.LoadSettings();
            var expected = AppSettingsDtoMock.Create();

            File.Exists(FILEPATH).Should().BeTrue();

            actual.Should().BeEquivalentTo(expected);

            File.Delete(FILEPATH);
        }
    }
}