using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;

namespace Notepad.Helpers
{
    public static class AppHelper
    {
        public static string FileName { get; set; }

        public static async Task ChangeWindowTitle(string title)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ApplicationView.GetForCurrentView().Title = FileName = title;
            });
        }
    }
}
