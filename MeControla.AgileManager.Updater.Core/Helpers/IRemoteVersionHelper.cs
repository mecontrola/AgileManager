using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public interface IRemoteVersionHelper
    {
        Task<Version> GetVersion(CancellationToken cancellationToken);
    }
}