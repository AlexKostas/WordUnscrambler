namespace WordUnscrambler.Utils {
    public static class Constants {
        public const string OptionsToEnterScrambledWords = "Enter scrambled word(s) manually or " +
                                           "as a file: " + File + " - file/" + Manual + " - manual";

        public const string OptionsToContinueTheProgram =
            "Would you like to continue? " + Yes + "/" + No;
        
        public const string EnterScrambledWordsViaFile = "Enter full plath including the file name";
        public const string EnterScrambledWordsManually = "Enter words manually separated by commas";
        public const string OptionNotRecognised = "The option was not recognised";
       
        public const string ErrorScrambledWordsCannotBeLoaded = "Scrambled words were not loaded" +
                                                                " because there was an error: ";
        public const string ErrorProgramWillBeTerminated = "The program will be terminated";
        
        public const string MatchFound = "Match found for {0}: {1}";
        public const string MatchNotFound = "No matches have been found";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFileName = "wordlist.txt";
    }
}