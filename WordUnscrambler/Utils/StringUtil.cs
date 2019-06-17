using System;

namespace WordUnscrambler.Utils {
    public static class StringUtil {
        public static bool StringsAreEqual(string string1, string string2) {
            return string1.Equals(string2, StringComparison.OrdinalIgnoreCase);
        }

        public static string SortString(string word) {
            var wordArray = word.ToCharArray();
            Array.Sort(wordArray);
            return new string(wordArray);
        }
    }
}