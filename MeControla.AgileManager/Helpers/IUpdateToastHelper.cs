using Windows.Foundation;
using Windows.UI.Notifications;

namespace MeControla.AgileManager.Helpers
{
    public interface IUpdateToastHelper
    {
        void Show(TypedEventHandler<ToastNotification, object> action);
    }
}