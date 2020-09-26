using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void EmptyTest()
        {
            string expected = "Foo\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\class\empty.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LocalReferenceSelfTest()
        {
            string expected = "Foo\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\class\local_reference_self.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReferenceSelfTest()
        {
            string expected = "Foo\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\class\reference_self.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
