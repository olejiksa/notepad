using System;
using System.Linq;

namespace Notepad.Helpers
{
    public static class TextHelper
    {
        public static Tuple<int, int> GetPosition(string text, string newline, int selectionStart)
        {
            int i, position = 0, line = 1, column;

            try
            {
                while ((i = text.IndexOf(newline, position, selectionStart - position)) != -1)
                {
                    position = i + 1;
                    line++;
                }
            }
            finally
            {
                column = selectionStart - position + 1;
            }

            return Tuple.Create(line, column);
        }

        public static int GetWordsCount(string text)
        {
            return text.Split(text.Where(c => char.IsPunctuation(c) || char.IsWhiteSpace(c) || char.IsDigit(c)).ToArray(),
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
