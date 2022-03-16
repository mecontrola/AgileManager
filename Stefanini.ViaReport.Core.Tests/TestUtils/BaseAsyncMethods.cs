using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.TestUtils
{
    public abstract class BaseAsyncMethods
    {
        private readonly CancellationTokenSource cancellationTokenSource;

        public BaseAsyncMethods()
        {
            cancellationTokenSource = new CancellationTokenSource();
        }

        protected CancellationToken GetCancellationToken()
            => cancellationTokenSource.Token;
    }
}