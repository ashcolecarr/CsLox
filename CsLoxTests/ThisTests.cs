using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class ThisTests
    {
        [TestMethod]
        public void ClosureTest()
        {
            string expected = "Foo\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\this\closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedClassTest()
        {
            string expected = "Outer instance\r\nOuter instance\r\nInner instance\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\this\nested_class.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedClosureTest()
        {
            string expected = "Foo\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\this\nested_closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThisAtTopLevelTest()
        {
            string expected = "[line 1] Error at 'this': Cannot use 'this' outside of a class.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\this\this_at_top_level.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThisInMethodTest()
        {
            string expected = "baz\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\this\this_in_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThisInTopLevelFunctionTest()
        {
            string expected = "[line 2] Error at 'this': Cannot use 'this' outside of a class.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\this\this_in_top_level_function.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
