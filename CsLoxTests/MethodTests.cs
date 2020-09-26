using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class MethodTests
    {
        [TestMethod]
        public void ArityTest()
        {
            string expected = "no args\r\n1\r\n3\r\n6\r\n10\r\n15\r\n21\r\n28\r\n36\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\method\arity.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmptyBlockTest()
        {
            string expected = "nil\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\method\empty_block.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtraArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 4.\r\n[line 8]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\method\extra_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 1.\r\n[line 5]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\method\missing_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotFoundTest()
        {
            string expected = "Undefined property 'unknown'.\r\n[line 3]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\method\not_found.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintBoundMethodTest()
        {
            string expected = "<fn method>\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\method\print_bound_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReferToNameTest()
        {
            string expected = "Undefined variable 'method'.\r\n[line 3]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\method\refer_to_name.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TooManyArgumentsTest()
        {
            string expected = "[line 259] Error at 'a': Cannot have more than 255 arguments.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\method\too_many_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TooManyParametersTest()
        {
            string expected = "[line 258] Error at 'a': Cannot have more than 255 parameters.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\method\too_many_parameters.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
