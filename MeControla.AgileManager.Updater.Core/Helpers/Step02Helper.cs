using MeControla.AgileManager.Updater.Core.Data.Configurations;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public class Step02Helper : IStep02Helper
    {
        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IToolsHelper toolsHelper;

        public Step02Helper(IUpdaterConfiguration updaterConfiguration,
                            IToolsHelper toolsHelper)
        {
            this.updaterConfiguration = updaterConfiguration;
            this.toolsHelper = toolsHelper;
        }

        public void Run()
        {
            var process = toolsHelper.FindProcessRunning(updaterConfiguration.ApplicationName);

            if (!process.HasProcess())
                return;

            process.Kill();
            process.WaitForExit();
            process.Dispose();
        }
    }
}