using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void AssociativityTest()
        {
            string expected = "c\r\nc\r\nc\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\assignment\associativity.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GlobalTest()
        {
            string expected = "before\r\nafter\r\narg\r\narg\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\assignment\global.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GroupingTest()
        {
            string expected = "[line 2] Error at '=': Invalid assignment target.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\assignment\grouping.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InfixOperatorTest()
        {
            string expected = "[line 3] Error at '=': Invalid assignment target.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\assignment\infix_operator.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LocalTest()
        {
            string expected = "before\r\nafter\r\narg\r\narg\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\assignment\local.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrefixOperatorTest()
        {
            string expected = "[line 2] Error at '=': Invalid assignment target.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\assignment\prefix_operator.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SyntaxTest()
        {
            string expected = "var\r\nvar\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\assignment\syntax.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UndefinedTest()
        {
            string expected = "Undefined variable 'unknown'.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\assignment\undefined.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
