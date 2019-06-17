namespace WordUnscrambler.Data {
    public struct MatchedWord {
        public string ScrambledWord { get; }
        public string Word { get; }

        public MatchedWord(string scrambledWord, string word) {
            ScrambledWord = scrambledWord;
            Word = word;
        }
    }
}