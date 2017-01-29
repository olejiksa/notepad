using System;
using System.Collections.ObjectModel;
using System.Linq;
using Notepad.Controls;
using Notepad.Helpers;
using Notepad.Models;
using Notepad.Views;
using OverToolkit.Mvvm;

namespace Notepad.ViewModels
{
    public class BackstageViewModel : BindableBase
    {
        private ObservableCollection<BackstageItem> items, bottomItems;
        private BackstageItem selectedMenuItem, selectedBottomMenuItem;

        public BackstageViewModel()
        {
            items = new ObservableCollection<BackstageItem>();
            items.Add(new BackstageItem { Caption = "Создать", Glyph = "\uE7C3", PageType = typeof(NewView) });
            items.Add(new BackstageItem { Caption = "Открыть", Glyph = "\uE8E5" });
            items.Add(new BackstageItem { Caption = "Сохранить", Glyph = "\uE74E" });
            items.Add(new BackstageItem { Caption = "Сохранить как", Glyph = "\uE28F" });
            items.Add(new BackstageItem { Caption = "Печать", Glyph = "\uE2F6" });
            items.Add(new BackstageItem { Caption = "Поделиться", Glyph = "\uE72D" });

            bottomItems = new ObservableCollection<BackstageItem>();
            bottomItems.Add(new BackstageItem { Caption = "Настройки", Glyph = "\uE713" });
            bottomItems.Add(new BackstageItem { Caption = "Обратная связь", Glyph = "\uE939" });
        }

        public string WindowTitle => $"{AppHelper.FileName} - {AppData.AppName}";

        public BackstageItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if (Set(ref selectedMenuItem, value) && value != null)
                    OnSelectedMenuItemChanged(true);
            }
        }

        public BackstageItem SelectedBottomMenuItem
        {
            get { return selectedBottomMenuItem; }
            set
            {
                if (Set(ref selectedBottomMenuItem, value) && value != null)
                    OnSelectedMenuItemChanged(false);
            }
        }

        public ObservableCollection<BackstageItem> Items => items;

        public ObservableCollection<BackstageItem> BottomItems => bottomItems;

        public Type SelectedPageType
        {
            get
            {
                return (selectedMenuItem ?? selectedBottomMenuItem)?.PageType;
            }
            set
            {
                SelectedMenuItem = items.FirstOrDefault(m => m.PageType == value);
                SelectedBottomMenuItem = bottomItems.FirstOrDefault(m => m.PageType == value);
            }
        }

        private void OnSelectedMenuItemChanged(bool top)
        {
            if (top)
                SelectedBottomMenuItem = null;
            else
                SelectedMenuItem = null;
            RaisePropertyChanged(nameof(SelectedPageType));
        }
    }
}
