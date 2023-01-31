using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using System;

namespace MeControla.AgileManager.Core.Builders.Configurations
{
    public class JiraConfigurationBuilder
    {
        private readonly JiraConfiguration obj;

        private JiraConfigurationBuilder()
            => obj = new();

        public JiraConfigurationBuilder SetUsername(string value)
            => Set(obj => obj.Username = value);

        public JiraConfigurationBuilder SetPassword(string value)
            => Set(obj => obj.Password = value);

        public JiraConfigurationBuilder SetUrl(string value)
            => Set(obj => obj.Url = value);

        public JiraConfigurationBuilder SetCache(int value)
            => Set(obj => obj.Cache = value);

        private JiraConfigurationBuilder Set(Action<JiraConfiguration> action)
        {
            action?.Invoke(obj);
            return this;
        }

        public JiraConfiguration ToBuild()
            => obj;

        public static JiraConfigurationBuilder GetInstance()
            => new();
    }
}