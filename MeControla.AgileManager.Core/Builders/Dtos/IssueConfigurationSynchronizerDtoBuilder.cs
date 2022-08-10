using MeControla.AgileManager.Data.Dtos.Settings;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Core.Builders.Dtos
{
    public class IssueConfigurationSynchronizerDtoBuilder
    {
        private readonly IssueConfigurationSynchronizerDto obj;

        private IssueConfigurationSynchronizerDtoBuilder()
            => obj = new();

        public IssueConfigurationSynchronizerDtoBuilder AddSettings(AppSettingsDto settings)
            => Set(x =>
            {
                x.Username = settings.Username;
                x.Password = settings.Password;
                x.SyncAllData = settings.SyncAllData;
            });

        public IssueConfigurationSynchronizerDtoBuilder AddProjects(IList<long> projects)
            => Set(x => x.Projects = projects.ToArray());

        private IssueConfigurationSynchronizerDtoBuilder Set(Action<IssueConfigurationSynchronizerDto> action)
        {
            action?.Invoke(obj);
            return this;
        }

        public IssueConfigurationSynchronizerDto ToBuild()
            => obj;

        public static IssueConfigurationSynchronizerDtoBuilder GetInstance()
            => new();
    }
}