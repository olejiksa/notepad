using OverToolkit.Common;

namespace Notepad.Models
{
    public static class ExtraLocator
    {
        public static INavigationHelper NavigationHelper { get; set; }

        public static void InitializeNavigationHelper(INavigationHelper navigationHelper)
        {
            NavigationHelper = navigationHelper;
        }
    }
}
