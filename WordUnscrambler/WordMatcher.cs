using System.Collections.Generic;
using WordUnscrambler.Utils;

namespace WordUnscrambler {
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
            return StringUtility.WordsAreEqual(scrambledWord, word) ||
                   StringUtility.WordsAreEqual(StringUtility.SortString(scrambledWord),
                       StringUtility.SortString(word));
        }


        static MatchedWord buildMatchedWord(string scrambledWord, string word) {
            return new MatchedWord(scrambledWord, word);
        }
    }
}