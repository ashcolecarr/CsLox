using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class ReturnTests
    {
        [TestMethod]
        public void AfterElseTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\return\after_else.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AfterIfTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\return\after_if.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AfterWhileTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\return\after_while.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AtTopLevelTest()
        {
            string expected = "[line 1] Error at 'return': Cannot return from top-level code.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\return\at_top_level.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InFunctionTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\return\in_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnNilIfNoValueTest()
        {
            string expected = "nil\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\return\return_nil_if_no_value.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
