using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void LeadingDotTest()
        {
            string expected = "[line 2] Error at '.': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\number\leading_dot.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LiteralsTest()
        {
            string expected = "123\r\n987654\r\n0\r\n0\r\n123.456\r\n-0.001\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\number\literals.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
