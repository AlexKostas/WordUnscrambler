using System.Collections.Generic;
using WordUnscrambler.Data;
using WordUnscrambler.Utils;

namespace WordUnscrambler.Core {
    public class WordMatcher {
        string[] wordList;

        public WordMatcher(string[] wordList) {
            this.wordList = wordList;
        }

        public List<MatchedWord> Match(string[] scrambledWords) {
            if (scrambledWords == null || scrambledWords.Length == 0)
                return new List<MatchedWord>();

            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords) {
                foreach (var word in wordList) {
                    if (compareScrambledWords(scrambledWord, word))
                        matchedWords.Add(buildMatchedWord(scrambledWord, word));
                }
            }

            return matchedWords;
        }

        bool compareScrambledWords(string scrambledWord, string word) {
            return StringUtil.StringsAreEqual(scrambledWord, word) ||
                   StringUtil.StringsAreEqual(StringUtil.SortString(scrambledWord),
                       StringUtil.SortString(word));
        }

        static MatchedWord buildMatchedWord(string scrambledWord, string word) {
            return new MatchedWord(scrambledWord, word);
        }
    }
}