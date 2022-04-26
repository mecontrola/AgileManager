using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public interface IRemoteVersionHelper
    {
        Task<Version> GetVersion(CancellationToken cancellationToken);
    }
}