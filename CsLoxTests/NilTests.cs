using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class NilTests
    {
        [TestMethod]
        public void LiteralTest()
        {
            string expected = "nil\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\nil\literal.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
