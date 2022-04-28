using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using System;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class Step04Helper : IStep04Helper
    {
        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IToolsHelper toolsHelper;

        public Step04Helper(IUpdaterConfiguration updaterConfiguration,
                            IToolsHelper toolsHelper)
        {
            this.updaterConfiguration = updaterConfiguration;
            this.toolsHelper = toolsHelper;
        }

        public void Run()
        {
            if (!toolsHelper.FileExists(updaterConfiguration.RenameFileDownloaded))
                return;

            toolsHelper.ZipExtractOverride(updaterConfiguration.RenameFileDownloaded, AppContext.BaseDirectory);

            toolsHelper.FileDelete(updaterConfiguration.RenameFileDownloaded);
        }
    }
}