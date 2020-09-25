using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class VariableTests
    {
        [TestMethod]
        public void CollideWithParameterTest()
        {
            string expected = "[line 2] Error at 'a': Variable with this name already declared in this scope.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\collide_with_parameter.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DuplicateLocalTest()
        {
            string expected = "[line 3] Error at 'a': Variable with this name already declared in this scope.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\duplicate_local.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DuplicateParameterTest()
        {
            string expected = "[line 2] Error at 'arg': Variable with this name already declared in this scope.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\duplicate_parameter.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EarlyBoundTest()
        {
            string expected = "outer\r\nouter\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\early_bound.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InMiddleOfBlockTest()
        {
            string expected = "a\r\na b\r\na c\r\na b d\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\in_middle_of_block.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InNestedBlockTest()
        {
            string expected = "outer\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\in_nested_block.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RedeclareGlobalTest()
        {
            string expected = "nil\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\redeclare_global.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RedefineGlobalTest()
        {
            string expected = "2\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\redefine_global.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScopeReuseInDifferentBlocksTest()
        {
            string expected = "first\r\nsecond\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\scope_reuse_in_different_blocks.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShadowAndLocalTest()
        {
            string expected = "outer\r\ninner\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\shadow_and_local.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShadowGlobalTest()
        {
            string expected = "shadow\r\nglobal\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\shadow_global.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShadowLocalTest()
        {
            string expected = "shadow\r\nlocal\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\shadow_local.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UndefinedGlobalTest()
        {
            string expected = "Undefined variable 'notDefined'.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\undefined_global.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UndefinedLocalTest()
        {
            string expected = "Undefined variable 'notDefined'.\r\n[line 2]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\undefined_local.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UninitializedTest()
        {
            string expected = "nil\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\uninitialized.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnreachedUndefinedTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\unreached_undefined.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UseFalseAsVarTest()
        {
            string expected = "[line 2] Error at 'false': Expect variable name.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\use_false_as_var.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UseLocalInInitializerTest()
        {
            string expected = "[line 3] Error at 'a': Cannot read local variable in its own initializer.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\use_local_in_initializer.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UseGlobalInInitializerTest()
        {
            string expected = "value\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\variable\use_global_in_initializer.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UseNilAsVarTest()
        {
            string expected = "[line 2] Error at 'nil': Expect variable name.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\use_nil_as_var.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UseThisAsVarTest()
        {
            string expected = "[line 2] Error at 'this': Expect variable name.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\variable\use_this_as_var.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
