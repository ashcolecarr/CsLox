using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void EmptyTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\block\empty.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScopeTest()
        {
            string expected = "inner\r\nouter\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\block\scope.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
