using Windows.Foundation;
using Windows.UI.Notifications;

namespace Stefanini.ViaReport.Helpers
{
    public interface IUpdateToastHelper
    {
        void Show(TypedEventHandler<ToastNotification, object> action);
    }
}