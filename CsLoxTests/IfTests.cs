using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class IfTests
    {
        [TestMethod]
        public void ClassInElseTest()
        {
            string expected = "[line 2] Error at 'class': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\if\class_in_else.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClassInThenTest()
        {
            string expected = "[line 2] Error at 'class': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\if\class_in_then.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DanglingElseTest()
        {
            string expected = "good\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\if\dangling_else.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ElseTest()
        {
            string expected = "good\r\ngood\r\nblock\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\if\else.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FunInElseTest()
        {
            string expected = "[line 2] Error at 'fun': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\if\fun_in_else.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FunInThenTest()
        {
            string expected = "[line 2] Error at 'fun': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\if\fun_in_then.lox");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IfTest()
        {
            string expected = "good\r\nblock\r\nTrue\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\if\if.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TruthTest()
        {
            string expected = "false\r\nnil\r\nTrue\r\n0\r\nempty\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\if\truth.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VarInElseTest()
        {
            string expected = "[line 2] Error at 'var': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\if\var_in_else.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VarInThenTest()
        {
            string expected = "[line 2] Error at 'var': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\if\var_in_then.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
