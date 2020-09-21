using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class BoolTests
    {
        [TestMethod]
        public void EqualityTest()
        {
            string expected = @"True
False
False
True
False
False
False
False
False
False
True
True
False
True
True
True
True
True
";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\bool\equality.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotTest()
        {
            string expected = "False\r\nTrue\r\nTrue\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\bool\not.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
