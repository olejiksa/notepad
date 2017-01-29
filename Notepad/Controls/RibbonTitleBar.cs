using OverToolkit.Common;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Notepad.Controls
{
    public sealed class RibbonTitleBar : Control
    {
        public RibbonTitleBar()
        {
            DefaultStyleKey = typeof(RibbonTitleBar);

            Loaded += RibbonTitleBar_Loaded;
            Window.Current.Activated += Current_Activated;
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title),
            typeof(string), typeof(RibbonTitleBar), new PropertyMetadata(null));

        public Visibility BackButtonVisibility
        {
            get { return (Visibility)GetValue(BackButtonVisibilityProperty); }
            set { SetValue(BackButtonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty BackButtonVisibilityProperty = DependencyProperty.Register(nameof(BackButtonVisibility),
            typeof(Visibility), typeof(RibbonTitleBar), new PropertyMetadata(null));

        private void RibbonTitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SetTitleBar((GetTemplateChild("backgroundElement") as Rectangle));

            Button backButton = GetTemplateChild("backButton") as Button;
            backButton.Click += BackButton_Click;
        }

        private void Current_Activated(object sender, WindowActivatedEventArgs e)
        {
            TextBlock ribbonTitle = GetTemplateChild("ribbonTitle") as TextBlock;
            Button backButton = GetTemplateChild("backButton") as Button;

            ribbonTitle.Opacity = backButton.Foreground.Opacity = e.WindowActivationState != CoreWindowActivationState.Deactivated ? 1 : 0.5;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Locator.NavigationHelper.CurrentFrame.GoBack();
        }
    }
}
