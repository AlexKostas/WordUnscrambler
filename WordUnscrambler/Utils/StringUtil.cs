using System;

namespace WordUnscrambler.Utils {
    public static class StringUtil {
        public static bool StringsAreEqual(string string1, string string2) {
            if(ArgumentIsInvalid(string1) || ArgumentIsInvalid(string2))
                throw new ArgumentNullException();
            string1 = string1.Trim();
            string2 = string2.Trim();
            return string1.Equals(string2, StringComparison.OrdinalIgnoreCase);
        }

        public static string SortString(string word) {
            if(ArgumentIsInvalid(word))
                throw new ArgumentNullException();
            var wordArray = word.Trim().ToCharArray();
            Array.Sort(wordArray);
            return new string(wordArray);
        }

        static bool ArgumentIsInvalid(string argument) {
            return string.IsNullOrWhiteSpace(argument);
        }
    }
}