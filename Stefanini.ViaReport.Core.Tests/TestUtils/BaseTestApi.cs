using System;
using System.Diagnostics.CodeAnalysis;
using WireMock.Server;

namespace Stefanini.ViaReport.Core.Tests.TestUtils
{
    public abstract class BaseTestApi : IDisposable
    {
        protected readonly WireMockServer server;

        protected BaseTestApi()
        {
            server = WireMockServer.Start();
        }

        [SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "<Pending>")]
        public void Dispose()
            => server.Stop();
    }
}