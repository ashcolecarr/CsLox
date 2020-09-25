using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void EmptyBodyTest()
        {
            string expected = "nil\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\function\empty_body.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtraArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 4.\r\n[line 6]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\function\extra_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LocalMutualRecursionTest()
        {
            string expected = "Undefined variable 'isOdd'.\r\n[line 4]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\function\local_mutual_recursion.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LocalRecursionTest()
        {
            string expected = "21\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\function\local_recursion.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 1.\r\n[line 3]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\function\missing_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingCommaInParametersTest()
        {
            string expected = "[line 3] Error at 'c': Expect ')' after parameters.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\function\missing_comma_in_parameters.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MutualRecursionTest()
        {
            string expected = "True\r\nTrue\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\function\mutual_recursion.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParametersTest()
        {
            string expected = "0\r\n1\r\n3\r\n6\r\n10\r\n15\r\n21\r\n28\r\n36\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\function\parameters.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintTest()
        {
            string expected = "<fn foo>\r\n<native fn>\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\function\print.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecursionTest()
        {
            string expected = "21\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\function\recursion.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TooManyArgumentsTest()
        {
            string expected = "[line 260] Error at 'a': Cannot have more than 255 arguments.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\function\too_many_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TooManyParametersTest()
        {
            string expected = "[line 257] Error at 'a': Cannot have more than 255 parameters.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\function\too_many_parameters.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
