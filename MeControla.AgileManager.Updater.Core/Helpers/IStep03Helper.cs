using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public interface IStep03Helper
    {
        Task Run(Action<bool, long> fncUpdateProgress, CancellationToken cancellationToken);
    }
}