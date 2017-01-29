using Notepad.Models;
using OverToolkit.Common;
using OverToolkit.Controls;
using Windows.UI.Xaml.Controls;

namespace Notepad.Views
{
    public sealed partial class BackstageView : View, INavigationHelper
    {
        public BackstageView()
        {
            InitializeComponent();
            ExtraLocator.InitializeNavigationHelper(this);
        }

       public Frame CurrentFrame => frame;
    }
}
