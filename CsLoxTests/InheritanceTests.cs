using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class InheritanceTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            string expected = "value\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\inheritance\constructor.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InheritFromFunctionTest()
        {
            string expected = "Superclass must be a class.\r\n[line 3]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\inheritance\inherit_from_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InheritFromNilTest()
        {
            string expected = "Superclass must be a class.\r\n[line 2]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\inheritance\inherit_from_nil.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InheritFromNumberTest()
        {
            string expected = "Superclass must be a class.\r\n[line 2]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\inheritance\inherit_from_number.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InheritMethodsTest()
        {
            string expected = "foo\r\nbar\r\nbar\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\inheritance\inherit_methods.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParenthesizedSuperclassTest()
        {
            string expected = "[line 4] Error at '(': Expect superclass name.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\inheritance\parenthesized_superclass.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetFieldsFromBaseClassTest()
        {
            string expected = "foo 1\r\nfoo 2\r\nbar 1\r\nbar 2\r\nbar 1\r\nbar 2\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\inheritance\set_fields_from_base_class.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
