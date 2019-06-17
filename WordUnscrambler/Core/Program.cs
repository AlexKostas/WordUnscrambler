using System;
using System.Linq;
using System.Collections.Generic;
using WordUnscrambler.Data;
using WordUnscrambler.Utils;

namespace WordUnscrambler.Core {
    public static class Program {
        static FileReader fileReader;
        static WordMatcher wordMatcher;

        static void Main() {
            try {
                fileReader = new FileReader();
                wordMatcher = new WordMatcher(fileReader.Read(Constants.WordListFileName));
                RunProgram();
            }
            catch (Exception e) {
                IOUtil.LogError(Constants.ErrorProgramWillBeTerminated + " " + e.Message);
                throw;
            }
        }

        static void RunProgram() {
            while (true) {
                IOUtil.Print(Constants.OptionsToEnterScrambledWords);
                var option = IOUtil.GetLine();
                handleUserOption(option);
                if (UserInput.shouldStopProgram()) break;
            }
        }

        static void handleUserOption(string option) {
            switch (option.ToUpper()) {
                case Constants.File:
                    IOUtil.Print(Constants.EnterScrambledWordsViaFile);
                    var words = wordMatcher.Match(UserInput.GetScrambledWordsFromFile());
                    DisplayMatchedWords(words);
                    break;
                case Constants.Manual:
                    IOUtil.Print(Constants.EnterScrambledWordsManually);
                    var wordList = wordMatcher.Match(UserInput.GetScrambledWordsManually());
                    DisplayMatchedWords(wordList);
                    break;
                default:
                    IOUtil.Print(Constants.OptionNotRecognised);
                    break;
            }
        }

        static void DisplayMatchedWords(List<MatchedWord> matchedWords) {
            if (matchedWords.Any())
                foreach (var matchedWord in matchedWords)
                    IOUtil.Print(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
            else
                IOUtil.Print(Constants.MatchNotFound);
        }
    }
}