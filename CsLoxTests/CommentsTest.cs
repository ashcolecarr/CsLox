using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class CommentsTest
    {
        [TestMethod]
        public void CommentTest()
        {

            string expected = "EOF  \r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\only_line_comment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CommentAndLineTest()
        {

            string expected = "EOF  \r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\only_line_comment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultilineCommentTest()
        {

            string expected = @"AND and 
IDENTIFIER space 
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\multiline_comment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MalformedMultilineCommentTest()
        {

            string expected = @"AND and 
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\comments\malformed_multiline_comment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MalformedMultilineCommentErrorTest()
        {

            string expected = "[line 5] Error : Unterminated comment.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\comments\malformed_multiline_comment.lox");

            Assert.AreEqual(expected, actual);
        }

    }
}
