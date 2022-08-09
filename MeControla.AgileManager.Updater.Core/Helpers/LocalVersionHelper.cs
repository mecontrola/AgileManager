using MeControla.AgileManager.Updater.Core.Data.Configurations;
using MeControla.Kernel.Extensions;
using System;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public class LocalVersionHelper : ILocalVersionHelper
    {
        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IToolsHelper toolsHelper;

        public LocalVersionHelper(IUpdaterConfiguration updaterConfiguration,
                                  IToolsHelper toolsHelper)
        {
            this.updaterConfiguration = updaterConfiguration;
            this.toolsHelper = toolsHelper;
        }

        public Version GetVersion()
            => GetVersionApp()?.GetVersion();

        private string GetVersionApp()
        {
            try
            {
                return toolsHelper.GetFileVersion(updaterConfiguration.ApplicationName);
            }
            catch
            {
                return null;
            }
        }
    }
}