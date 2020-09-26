using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void ArgumentsTest()
        {
            string expected = "init\r\n1\r\n2\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\constructor\arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallInitEarlyReturnTest()
        {
            string expected = "init\r\ninit\r\nFoo instance\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\constructor\call_init_early_return.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallInitExplicitlyTest()
        {
            string expected = "Foo.init(one)\r\nFoo.init(two)\r\nFoo instance\r\ninit\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\constructor\call_init_explicitly.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultTest()
        {
            string expected = "Foo instance\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\constructor\default.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefaultArgumentsTest()
        {
            string expected = "Expected 0 arguments but got 3.\r\n[line 3]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\constructor\default_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EarlyReturnTest()
        {
            string expected = "init\r\nFoo instance\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\constructor\early_return.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtraArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 4.\r\n[line 8]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\constructor\extra_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InitNotMethodTest()
        {
            string expected = "not initializer\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\constructor\init_not_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 1.\r\n[line 5]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\constructor\missing_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnInNestedFunctionTest()
        {
            string expected = "bar\r\nFoo instance\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\constructor\return_in_nested_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnValueTest()
        {
            string expected = "[line 3] Error at 'return': Cannot return a value from an initializer.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\constructor\return_value.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
