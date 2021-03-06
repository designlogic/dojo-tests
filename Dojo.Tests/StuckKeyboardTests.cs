using Dojo.Rooms;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Tests
{
    public class StuckKeyboardTests : TestBase
    {
        /*
        Summary
            You are given two strings typed and target. You want to write target, 
            but the keyboard is stuck so some characters may be written 1 or more times. 
            Return whether it's possible that typed was meant to write target.
        Input
            typed = "aaabcccc"
            target = "abc"
        Output
            True
        Explanation
            Each of the "a", "b", and "c" were typed
         */

        private readonly StuckKeyboard sut = new();

        public StuckKeyboardTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("aaaa", "a", true)]
        [InlineData("aaaabcccc", "abc", true)]
        [InlineData("ccaaaaaat", "cat", true)]
        [InlineData("cat", "cat", true)]
        [InlineData("mmmoooo", "moo", true)]
        [InlineData("mmmoooo", "mooo", true)]
        [InlineData("mmmoooo", "moooo", true)]
        [InlineData("mmmoooonn", "moon", true)]
        [InlineData("mmmoooonan", "moon", false)]
        [InlineData("aaaab", "a", false)]
        [InlineData("abc", "ab", false)]
        [InlineData("abccccccc", "ab", false)]
        [InlineData("ab", "abc", false)]
        [InlineData("fbbbbbbaaattt", "ball", false)]
        [InlineData("bbbbbbaaattt", "ball", false)]
        public void StuckKeyboard(string typed, string target, bool expectedResult)
        {
            bool result = sut.Process(typed,target);

            result.ShouldBe(expectedResult, $"Typed: {typed} Target{target}");
        }
    }
}
