using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void ErrorAfterMultilineTest()
        {
            string expected = "Undefined variable 'err'.\r\n[line 7]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\string\error_after_multiline.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void LiteralsTest()
        {
            string expected = "()\r\na string\r\nA~¶Þॐஃ\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\string\literals.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultilineTest()
        {
            string expected = "1\r\n2\r\n3\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\string\multiline.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnterminatedTest()
        {
            string expected = "[line 2] Error: Unterminated string.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\string\unterminated.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
