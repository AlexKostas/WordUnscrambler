using System;
using WordUnscrambler.Utils;

namespace WordUnscrambler.Core {
    public static class UserInput {
        static readonly FileReader fileReader = new FileReader();

        public static string[] GetScrambledWordsFromFile() {
            try {
                var fileName = IOUtil.GetLine();
                return fileReader.Read(fileName);
            }
            catch (Exception ex) {
                IOUtil.LogError(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
                return null;
            }
        }

        public static string[] GetScrambledWordsManually() {
            var manualInput = IOUtil.GetLine();
            return manualInput.Split(",");
        }
        
        public static bool shouldStopProgram() {
            return StringUtil.StringsAreEqual(Constants.No, getContinueDesicion());
        }

        static string getContinueDesicion() {
            string continueDecision;
            while (true) {
                IOUtil.Print(Constants.OptionsToContinueTheProgram);
                continueDecision = IOUtil.GetLine();
                if (StringUtil.StringsAreEqual(continueDecision, Constants.Yes) ||
                    StringUtil.StringsAreEqual(continueDecision, Constants.No))
                    return continueDecision;
            }
        }
    }
}