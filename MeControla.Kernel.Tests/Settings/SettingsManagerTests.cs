using FluentAssertions;
using MeControla.Kernel.Settings;
using MeControla.Kernel.Tests.Mocks.Entities.Settings;
using System.IO;
using Xunit;

namespace MeControla.Kernel.Tests.Settings
{
    public class SettingsManagerTests
    {
        private static readonly string FILEPATH = Path.Combine(Directory.GetCurrentDirectory(), FILENAME);

        private const string FILENAME = "settings.test";

        [Fact(DisplayName = "[SettingsManager.LoadSettings] Deve carregar as informações padrões quando não houvem alterações de configuração.")]
        public void DeveCarregarInformacoesPadroesArquivo()
        {
            var settings = new SettingsManager<UserSettings>(FILENAME);

            var actual = settings.LoadSettings();
            var expected = UserSettingsMock.CreateEmpty();

            File.Exists(FILEPATH).Should().BeTrue();

            actual.Should().BeEquivalentTo(expected);

            File.Delete(FILEPATH);
        }

        [Fact(DisplayName = "[SettingsManager.LoadSettings] Deve carregar as informações quando forem salvas as alterações de configuração.")]
        public void DeveCarregarInformacoesAlteradasArquivo()
        {
            var settings = new SettingsManager<UserSettings>(FILENAME)
            {
                Data = UserSettingsMock.Create()
            };
            settings.SaveSettings();

            var actual = settings.LoadSettings();
            var expected = UserSettingsMock.Create();

            File.Exists(FILEPATH).Should().BeTrue();

            actual.Should().BeEquivalentTo(expected);

            File.Delete(FILEPATH);
        }
    }
}