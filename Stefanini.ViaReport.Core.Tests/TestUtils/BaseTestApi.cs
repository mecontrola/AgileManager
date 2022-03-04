using System;
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

        public void Dispose()
            => server.Stop();
    }
}