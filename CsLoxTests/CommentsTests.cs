using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class CommentsTests
    {
        [TestMethod]
        public void LineAtEofTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\line_at_eof.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyLineCommentTest()
        {
            string expected = "";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\only_line_comment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyLineCommentAndLineTest()
        {
            string expected = "";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\only_line_comment_and_line.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultilineCommentTest()
        {
            string expected = "ok\r\n2\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\multiline_comment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MalformedMultilineCommentTest()
        {
            string expected = "";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\malformed_multiline_comment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MalformedMultilineCommentErrorTest()
        {
            string expected = "[line 5] Error: Unterminated comment.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\comments\malformed_multiline_comment.lox");

            Assert.AreEqual(expected, actual);
        }

    }
}
