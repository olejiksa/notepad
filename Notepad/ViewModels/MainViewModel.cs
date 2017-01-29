using System;
using Notepad.Helpers;
using Notepad.Models;
using OverToolkit.Mvvm;

namespace Notepad.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private int selectedRow, selectedColumn, charactersCount, wordsCount, selectionStart;
        private string windowTitle, text, newline;
        private bool isStatusBarVisible, isSpellEnabled;

        public MainViewModel()
        {
            WindowTitle = "Безымянный";
            Newline = "CR";
            SelectedRow = SelectedColumn = 1;

            ViewLoadedCommand = new DelegateCommand(() =>
            {
                AppHelper.ChangeWindowTitle("Безымянный").GetAwaiter();
            });
        }

        public DelegateCommand ViewLoadedCommand { get; }
        
        public bool IsStatusBarVisible
        {
            get { return isStatusBarVisible; }
            set
            {
                Set(ref isStatusBarVisible, value);
                RaisePropertyChanged(nameof(IsStatusBarVisible));
            }
        }

        public bool IsSpellEnabled
        {
            get { return isSpellEnabled; }
            set
            {
                Set(ref isSpellEnabled, value);
                RaisePropertyChanged(nameof(IsSpellEnabled));
            }
        }

        public string WindowTitle
        {
            get { return windowTitle; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;

                AppHelper.ChangeWindowTitle(value).GetAwaiter();

                Set(ref windowTitle, $"{value} - {AppData.AppName}");
                RaisePropertyChanged(nameof(WindowTitle));
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                CharactersCount = value.Replace(AppData.NewLine, "").Length;
                WordsCount = TextHelper.GetWordsCount(value);

                Tuple<int, int> position = TextHelper.GetPosition(value, AppData.NewLine, SelectionStart);
                SelectedRow = position.Item1;
                SelectedColumn = position.Item2;

                Set(ref text, value);
                RaisePropertyChanged(nameof(Text));
            }
        }

        public string Newline
        {
            get { return newline; }
            set
            {
                Set(ref newline, value);
                RaisePropertyChanged(nameof(Newline));
            }
        }

        public int SelectedRow
        {
            get { return selectedRow; }
            set
            {
                Set(ref selectedRow, value);
                RaisePropertyChanged(nameof(SelectedRow));
            }
        }

        public int SelectedColumn
        {
            get { return selectedColumn; }
            set
            {
                Set(ref selectedColumn, value);
                RaisePropertyChanged(nameof(SelectedColumn));
            }
        }

        public int CharactersCount
        {
            get { return charactersCount; }
            set
            {
                Set(ref charactersCount, value);
                RaisePropertyChanged(nameof(CharactersCount));
            }
        }

        public int WordsCount
        {
            get { return wordsCount; }
            set
            {
                Set(ref wordsCount, value);
                RaisePropertyChanged(nameof(WordsCount));
            }
        }

        public int SelectionStart
        {
            get { return selectionStart; }
            set
            {
                Tuple<int, int> position = TextHelper.GetPosition(Text, AppData.NewLine, value);
                SelectedRow = position.Item1;
                SelectedColumn = position.Item2;

                Set(ref selectionStart, value);
                RaisePropertyChanged(nameof(SelectionStart));
            }
        }
    }
}
