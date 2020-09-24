using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class LogicalOperatorTests
    {
        [TestMethod]
        public void AndTest()
        {
            string expected = "False\r\n1\r\nFalse\r\nTrue\r\n3\r\nTrue\r\nFalse\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\logical_operator\and.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AndTruthTest()
        {
            string expected = "False\r\nnil\r\nok\r\nok\r\nok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\logical_operator\and_truth.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrTest()
        {
            string expected = "1\r\n1\r\nTrue\r\nFalse\r\nFalse\r\nFalse\r\nTrue\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\logical_operator\or.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrTruthTest()
        {
            string expected = "ok\r\nok\r\nTrue\r\n0\r\ns\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\logical_operator\or_truth.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
