using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public interface IDownloadFileHelper
    {
        Task Start(string url, string filename, Action<bool, long> fncUpdateProgress, CancellationToken cancellationToken);
    }
}