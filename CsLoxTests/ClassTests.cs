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
        public void InheritSelfTest()
        {
            string expected = "[line 1] Error at 'Foo': A class cannot inherit from itself.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\class\inherit_self.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InheritedMethodTest()
        {
            string expected = "in foo\r\nin bar\r\nin baz\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\class\inherited_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LocalInheritOtherTest()
        {
            string expected = "B\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\class\local_inherit_other.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LocalInheritSelfTest()
        {
            string expected = "[line 2] Error at 'Foo': A class cannot inherit from itself.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\class\local_inherit_self.lox");

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
