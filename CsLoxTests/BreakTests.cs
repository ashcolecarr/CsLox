using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class BreakTests
    {
        [TestMethod]
        public void BreakLoopTest()
        {
            string expected = "0\r\n1\r\n2\r\n3\r\n4\r\n10\r\n9\r\n8\r\n7\r\n6\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\break\break_loop.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BreakIsOutsideLoopTest()
        {
            string expected = "[line 2] Error at 'break': Break statement must be inside a loop.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\break\break_is_outside_loop.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
