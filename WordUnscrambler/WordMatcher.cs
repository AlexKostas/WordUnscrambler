using System;
using System.Collections.Generic;

namespace WordUnscrambler {
    public class WordMatcher {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList) {
            if(scrambledWords == null || scrambledWords.Length == 0)
                return new List<MatchedWord>();
            
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords) {
                foreach (var word in wordList) {
                    if(scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    else {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();
                        
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);
                        
                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);
                        if (sortedScrambledWord.Equals(sortedWord,
                            StringComparison.OrdinalIgnoreCase)) {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }
            }
            
            return matchedWords;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word) {
            return new MatchedWord(scrambledWord, word);
        }
    }
}