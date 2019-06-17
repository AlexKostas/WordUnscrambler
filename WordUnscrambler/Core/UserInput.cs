using System;
using WordUnscrambler.Utils;

namespace WordUnscrambler.Core {
    public static class UserInput {
        public static string[] GetScrambledWordsFromFile() {
            try {
                var fileName = IOUtil.GetLine();
                return FileReader.Read(fileName);
            }
            catch (Exception ex) {
                IOUtil.LogError(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
                return null;
            }
        }

        public static string[] GetScrambledWordsManually() {
            return IOUtil.GetSplittedLine(",");
        }
        
        public static bool ShouldStopProgram() {
            return StringUtil.StringsAreEqual(Constants.No, GetContinueDesicion());
        }

        static string GetContinueDesicion() {
            string continueDecision;
            while (true) {
                IOUtil.Print(Constants.OptionsToContinueTheProgram);
                continueDecision = IOUtil.GetLine();
                if (StringIsYesOrNo(continueDecision))
                    return continueDecision;
            }
        }

        static bool StringIsYesOrNo(string input) {
            return StringUtil.StringsAreEqual(input, Constants.Yes) ||
                   StringUtil.StringsAreEqual(input, Constants.No);
        }
    }
}