using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class WhileTests
    {
        [TestMethod]
        public void ClosureInBodyTest()
        {
            string expected = "1\r\n2\r\n3\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\while\closure_in_body.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FunInBodyTest()
        {
            string expected = "[line 2] Error at 'fun': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\while\fun_in_body.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnClosureTest()
        {
            string expected = "i\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\while\return_closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnInsideTest()
        {
            string expected = "i\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\while\return_inside.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SyntaxTest()
        {
            string expected = "1\r\n2\r\n3\r\n0\r\n1\r\n2\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\while\syntax.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VarInBodyTest()
        {
            string expected = "[line 2] Error at 'var': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\while\var_in_body.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
