using System;

namespace WordUnscrambler.Utils {
    public static class StringUtility {
        public static bool WordsAreEqual(string scrambledWord, string word) {
            return scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase);
        }

        public static string SortString(string word) {
            var wordArray = word.ToCharArray();
            Array.Sort(wordArray);
            return new string(wordArray);
        }
    }
}