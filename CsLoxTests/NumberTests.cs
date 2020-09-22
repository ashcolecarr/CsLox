using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void LiteralsTest()
        {
            string expected = "123\r\n987654\r\n0\r\n0\r\n123.456\r\n-0.001\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\number\literals.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
