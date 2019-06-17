namespace WordUnscrambler.Data {
    public struct MatchedWord {
        public string ScrambledWord { get; set; }
        public string Word { get; set; }

        public MatchedWord(string scrambledWord, string word) {
            ScrambledWord = scrambledWord;
            Word = word;
        }
    }
}