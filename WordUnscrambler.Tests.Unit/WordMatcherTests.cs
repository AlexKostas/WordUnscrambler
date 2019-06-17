using NUnit.Framework;
using WordUnscrambler.Core;

namespace WordUnscrambler.UnitTests {
    [TestFixture]
    public class WordMatcherTests {
        WordMatcher wordMatcher;

        [SetUp]
        public void Setup() {
            wordMatcher = new WordMatcher(new []{"cat", "chair", "more"});
        }
        
        [Test]
        public void Match_GivenScrambledWord_ReturnsUnscrambledWord() {
            string[] scrambledWords = {"omre"};
            
            var matchedWords = wordMatcher.Match(scrambledWords);
            
            Assert.That(matchedWords.Count, Is.EqualTo(1));
            Assert.That(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.That(matchedWords[0].Word.Equals("more"));
        }
        
        [Test]
        public void Match_GivenScrambledWords_ReturnsUnscrambledWordList() {
            string[] scrambledWords = {"omre", "act"};
            
            var matchedWords = wordMatcher.Match(scrambledWords);
            
            Assert.That(matchedWords.Count, Is.EqualTo(2));
            
            Assert.That(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.That(matchedWords[0].Word.Equals("more"));
            
            Assert.That(matchedWords[1].ScrambledWord.Equals("act"));
            Assert.That(matchedWords[1].Word.Equals("cat"));
        }

        [Test]
        public void Match_GivenNullScrambledWordsList_ReturnsEmptyList() {
            string[] test = { };
            var matchedWords = wordMatcher.Match(null);
            var matchedWords2 = wordMatcher.Match(test);
            
            Assert.That(matchedWords, Is.Empty);
            Assert.That(matchedWords2, Is.Empty);
        }
    }
}