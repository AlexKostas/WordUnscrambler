using NUnit.Framework;

namespace WordUnscrambler.UnitTests {
    [TestFixture]
    public class WordMatcherTests {
        readonly WordMatcher wordMatcher = new WordMatcher();

        [Test]
        public void Match_GivenScrambledWord_ReturnsUnscrambledWord() {
            string[] words = {"cat", "chair", "more"};
            string[] scrambledWords = {"omre"};
            
            var matchedWords = wordMatcher.Match(scrambledWords, words);
            
            Assert.That(matchedWords.Count, Is.EqualTo(1));
            Assert.That(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.That(matchedWords[0].Word.Equals("more"));
        }
        
        [Test]
        public void Match_GivenScrambledWords_ReturnsUnscrambledWordList() {
            string[] words = {"cat", "chair", "more"};
            string[] scrambledWords = {"omre", "act"};
            
            var matchedWords = wordMatcher.Match(scrambledWords, words);
            
            Assert.That(matchedWords.Count, Is.EqualTo(2));
            
            Assert.That(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.That(matchedWords[0].Word.Equals("more"));
            
            Assert.That(matchedWords[1].ScrambledWord.Equals("act"));
            Assert.That(matchedWords[1].Word.Equals("cat"));
        }

        [Test]
        public void Match_GivenNullScrambledWordsList_ReturnsEmptyList() {
            string[] words = {"cat", "chair", "more"};
            string[] test = { };
            var matchedWords = wordMatcher.Match(null, words);
            var matchedWords2 = wordMatcher.Match(test, words);
            
            Assert.That(matchedWords, Is.Empty);
            Assert.That(matchedWords2, Is.Empty);
        }
    }
}