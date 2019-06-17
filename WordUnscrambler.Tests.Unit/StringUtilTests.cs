using NUnit.Framework;
using WordUnscrambler.Utils;

namespace WordUnscrambler.UnitTests {
    [TestFixture]
    public class StringUtilTests {
        [Test]
        [TestCase("abc", "abc")]
        [TestCase("ABC", "abc")]
        [TestCase("aBC", "aBc")]
        [TestCase("  abc", "abc   ")]
        [TestCase(" AbC  ", " aBc")]
        public void
            StringsAreEqual_GivenTwoEqualStrings_ReturnsTrue(string string1, string string2) {
            Assert.IsTrue(StringUtil.StringsAreEqual(string1, string2));
        }

        [Test]
        public void StringsAreEqual_GivenTwoNonEqualStrings_ReturnsFalse() {
            Assert.IsFalse(StringUtil.StringsAreEqual("abc", "cba"));
        }

        [Test]
        [TestCase("")]
        [TestCase("    ")]
        [TestCase(null)]
        public void StringsAreEqual_GivenInvalidInput_ThrowsArgumentNullException(string inp) {
            Assert.That(() => StringUtil.StringsAreEqual(inp, inp), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("abc", "abc")]
        [TestCase("cba", "abc")]
        [TestCase("acb", "abc")]
        [TestCase(" cba  ", "abc")]
        public void SortString_GivenAString_ReturnTheStringSorted(string inp, string expected) {
            Assert.That(StringUtil.SortString(inp), Is.EqualTo(expected));
        }
        
        [Test]
        [TestCase("")]
        [TestCase("    ")]
        [TestCase(null)]
        public void SortString_GivenInvalidInput_ThrowsArgumentNullException(string inp) {
            Assert.That(() => StringUtil.SortString(inp), Throws.ArgumentNullException);
        }
    }
}