using NSubstitute;
using Stefanini.ViaReport.Updater.Core.Tests.Data.Utils;

namespace Stefanini.ViaReport.Updater.Core.Tests.Mocks.Utils
{
    public class ActionUpdateMock
    {
        public static IActionUpdate Create()
            => Substitute.For<IActionUpdate>();
    }
}