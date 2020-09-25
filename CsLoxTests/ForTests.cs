using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class ForTests
    {
        [TestMethod]
        public void ClosureInBodyTest()
        {
            string expected = "4\r\n1\r\n4\r\n2\r\n4\r\n3\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\for\closure_in_body.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FunInBodyTest()
        {
            string expected = "[line 2] Error at 'fun': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\for\fun_in_body.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnClosureTest()
        {
            string expected = "i\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\for\return_closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnInsideTest()
        {
            string expected = "i\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\for\return_inside.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScopeTest()
        {
            string expected = "0\r\n-1\r\nafter\r\n0\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\for\scope.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatementConditionTest()
        {
            string expected = "[line 3] Error at '{': Expect expression.\r\n[line 3] Error at ')': Expect ';' after expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\for\statement_condition.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatementIncrementTest()
        {
            string expected = "[line 2] Error at '{': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\for\statement_increment.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StatementInitializerTest()
        {
            string expected = "[line 3] Error at '{': Expect expression.\r\n[line 3] Error at ')': Expect ';' after expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\for\statement_initializer.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VarInBodyTest()
        {
            string expected = "[line 2] Error at 'var': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\for\var_in_body.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
