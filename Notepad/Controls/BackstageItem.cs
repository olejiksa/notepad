using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Notepad.Controls
{
    public sealed class BackstageItem : Control
    {
        public BackstageItem()
        {
            DefaultStyleKey = typeof(BackstageItem);
        }

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(nameof(Caption),
            typeof(string), typeof(BackstageItem), new PropertyMetadata(null));

        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(nameof(Glyph),
            typeof(string), typeof(BackstageItem), new PropertyMetadata(null));

        public Type PageType
        {
            get { return (Type)GetValue(PageTypeProperty); }
            set { SetValue(PageTypeProperty, value); }
        }

        public static readonly DependencyProperty PageTypeProperty = DependencyProperty.Register(nameof(PageType),
            typeof(Type), typeof(BackstageItem), new PropertyMetadata(null));
    }
}
