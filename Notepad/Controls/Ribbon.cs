using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Notepad.Controls
{
    [ContentProperty(Name = nameof(Tabs))]
    public sealed class Ribbon : ContentControl
    {
        private GridView gridView;

        public Ribbon()
        {
            DefaultStyleKey = typeof(Ribbon);

            Loaded += Ribbon_Loaded;

            Tabs = new ObservableCollection<RibbonTab>();
            Home = new ObservableCollection<UIElement>();
            View = new ObservableCollection<UIElement>();
        }

        public ObservableCollection<RibbonTab> Tabs
        {
            get { return (ObservableCollection<RibbonTab>)GetValue(TabsProperty); }
            set { SetValue(TabsProperty, value); }
        }

        public static readonly DependencyProperty TabsProperty = DependencyProperty.Register(nameof(Tabs),
            typeof(ObservableCollection<RibbonTab>), typeof(Ribbon), new PropertyMetadata(null));

        public ObservableCollection<UIElement> Home
        {
            get { return (ObservableCollection<UIElement>)GetValue(HomeTabProperty); }
            set { SetValue(HomeTabProperty, value); }
        }

        public static readonly DependencyProperty HomeTabProperty = DependencyProperty.Register(nameof(Home),
            typeof(ObservableCollection<UIElement>), typeof(Ribbon), new PropertyMetadata(null));

        public ObservableCollection<UIElement> View
        {
            get { return (ObservableCollection<UIElement>)GetValue(ViewTabProperty); }
            set { SetValue(ViewTabProperty, value); }
        }

        public static readonly DependencyProperty ViewTabProperty = DependencyProperty.Register(nameof(View),
            typeof(ObservableCollection<UIElement>), typeof(Ribbon), new PropertyMetadata(null));

        private void Ribbon_Loaded(object sender, RoutedEventArgs e)
        {
            gridView = GetTemplateChild("gridView") as GridView;
            gridView.SelectedIndex = 0;
            gridView.SelectionChanged += GridView_SelectionChanged;
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (gridView.SelectedIndex)
            {
                case 0:
                    (GetTemplateChild("home") as ItemsControl).Visibility = Visibility.Visible;
                    (GetTemplateChild("view") as ItemsControl).Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    (GetTemplateChild("home") as ItemsControl).Visibility = Visibility.Collapsed;
                    (GetTemplateChild("view") as ItemsControl).Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
