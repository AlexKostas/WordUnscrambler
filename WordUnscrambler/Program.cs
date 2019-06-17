using System;
using System.Linq;
using System.Collections.Generic;

namespace WordUnscrambler {
    class Program {
        static readonly FileReader fileReader = new FileReader();
        static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args) {
            bool continueWordUnscramble;
            do {
                Console.WriteLine(Constants.OptionsToEnterScrambledWords);
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper()) {
                    case Constants.File:
                        Console.WriteLine(Constants.EnterScrambledWordsViaFile);
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case Constants.Manual:
                        Console.WriteLine(Constants.EnterScrambledWordsManually);
                        ExecuteScrambledWordsInManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine(Constants.OptionNotRecognised);
                        break;
                }

                string continueDecision;

                do {
                    Console.WriteLine(Constants.OptionsToContinueTheProgram);
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while (!continueDecision.Equals(Constants.Yes,
                             StringComparison.OrdinalIgnoreCase) &&
                         !continueDecision
                             .Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble =
                    continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
            } while (continueWordUnscramble);
        }

        static void ExecuteScrambledWordsInFileScenario() {
            try {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = fileReader.Read(fileName);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex) {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ": " + ex.Message);
            }
        }

        static void ExecuteScrambledWordsInManualEntryScenario() {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(",");
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        static void DisplayMatchedUnscrambledWords(string[] scrambledWords) {
            string[] wordList = fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any()) {
                foreach (var matchedWord in matchedWords) {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord,
                        matchedWord.Word);
                }
            }
            else {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}