using NSubstitute;
using MeControla.AgileManager.Updater.Core.Tests.Data.Utils;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Utils
{
    public class ActionUpdateMock
    {
        public static IActionUpdate Create()
            => Substitute.For<IActionUpdate>();
    }
}