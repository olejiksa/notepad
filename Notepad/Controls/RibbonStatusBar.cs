using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Notepad.Controls
{
    public sealed class RibbonStatusBar : Control
    {
        public RibbonStatusBar()
        {
            DefaultStyleKey = typeof(RibbonStatusBar);
        }

        public string SelectedRow
        {
            get { return (string)GetValue(SelectedRowProperty); }
            set { SetValue(SelectedRowProperty, value); }
        }

        public static readonly DependencyProperty SelectedRowProperty = DependencyProperty.Register(nameof(SelectedRow),
            typeof(string), typeof(RibbonStatusBar), new PropertyMetadata(null));

        public string SelectedColumn
        {
            get { return (string)GetValue(SelectedColumnProperty); }
            set { SetValue(SelectedColumnProperty, value); }
        }

        public static readonly DependencyProperty SelectedColumnProperty = DependencyProperty.Register(nameof(SelectedColumn),
            typeof(string), typeof(RibbonStatusBar), new PropertyMetadata(null));

        public string CharactersCount
        {
            get { return (string)GetValue(CharactersCountProperty); }
            set { SetValue(CharactersCountProperty, value); }
        }

        public static readonly DependencyProperty CharactersCountProperty = DependencyProperty.Register(nameof(CharactersCount),
            typeof(string), typeof(RibbonStatusBar), new PropertyMetadata(null));

        public string WordsCount
        {
            get { return (string)GetValue(WordsCountProperty); }
            set { SetValue(WordsCountProperty, value); }
        }

        public static readonly DependencyProperty WordsCountProperty = DependencyProperty.Register(nameof(WordsCount),
            typeof(string), typeof(RibbonStatusBar), new PropertyMetadata(null));

        public string Newline
        {
            get { return (string)GetValue(NewlineProperty); }
            set { SetValue(NewlineProperty, value); }
        }

        public static readonly DependencyProperty NewlineProperty = DependencyProperty.Register(nameof(Newline),
            typeof(string), typeof(RibbonStatusBar), new PropertyMetadata(null));
    }
}
