using OverToolkit.Controls;
using Windows.UI.Xaml.Navigation;

namespace Notepad.Views
{
    public sealed partial class MainView : View
    {
        public MainView()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}
