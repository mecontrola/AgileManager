using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Configurations;

namespace MeControla.AgileManager.Core.Integrations
{
    public abstract class BaseConfigurationJiraIntegration
    {
        private readonly ISettingsService settings;

        protected BaseConfigurationJiraIntegration(ISettingsService settings)
        {
            this.settings = settings;
        }

        protected IJiraConfiguration JiraConfiguration { get; set; }

        private IJiraConfiguration GetConfiguration()
            => settings.GetJiraConfiguration();

        protected void LoadJiraConfiguration()
            => JiraConfiguration = GetConfiguration();
    }
}