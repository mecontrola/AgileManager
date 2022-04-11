using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.UI.Notifications;

namespace Stefanini.ViaReport.Helpers
{
    public class UpdateToastHelper : IUpdateToastHelper
    {
        private const string TITLE = "New update available";
        private const string MESSAGE = "Perform the update by accessing the menu Help and Update";

        private const string XML = @$"<toast>
                                          <visual>
                                              <binding template=""ToastImageAndText04"">
                                                  <image id=""1"" src=""file:///C:\meziantou.jpeg""/>
                                                  <text id=""1"">{TITLE}</text>
                                                  <text id=""2"">{MESSAGE}</text>
                                              </binding>
                                          </visual>
                                      </toast>";

        public void Show(TypedEventHandler<ToastNotification, object> action)
            => ToastNotificationManager.CreateToastNotifier(MainWindow.APP_TITLE)
                                       .Show(CreateToastNotification(action));

        private static ToastNotification CreateToastNotification(TypedEventHandler<ToastNotification, object> action)
        {
            var toast = new ToastNotification(CreateToastXml());
            toast.Activated += action;
            return toast;
        }

        private static XmlDocument CreateToastXml()
        {
            var toastXml = new XmlDocument();
            toastXml.LoadXml(XML);
            return toastXml;
        }
    }
}