using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class SuperTests
    {
        [TestMethod]
        public void BoundMethodTest()
        {
            string expected = "A.method(arg)\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\bound_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallOtherMethodTest()
        {
            string expected = "Derived.bar()\r\nBase.foo()\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\call_other_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CallSameMethodTest()
        {
            string expected = "Derived.foo()\r\nBase.foo()\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\call_same_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClosureTest()
        {
            string expected = "Base\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            string expected = "Derived.init()\r\nBase.init(a, b)\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\constructor.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExtraArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 4.\r\n[line 10]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\extra_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndirectlyInheritedTest()
        {
            string expected = "C.foo()\r\nA.foo()\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\indirectly_inherited.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MissingArgumentsTest()
        {
            string expected = "Expected 2 arguments but got 1.\r\n[line 9]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\missing_arguments.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoSuperclassBindTest()
        {
            string expected = "[line 3] Error at 'super': Cannot use 'super' in a class with no superclass.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\no_superclass_bind.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoSuperclassCallTest()
        {
            string expected = "[line 3] Error at 'super': Cannot use 'super' in a class with no superclass.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\no_superclass_call.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoSuperclassMethodTest()
        {
            string expected = "Undefined property 'doesNotExist'.\r\n[line 5]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\no_superclass_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParenthesizedTest()
        {
            string expected = "[line 8] Error at ')': Expect '.' after 'super'.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\parenthesized.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReassignSuperclassTest()
        {
            string expected = "Base.method()\r\nBase.method()\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\reassign_superclass.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuperAtTopLevelTest()
        {
            string expected = @"[line 1] Error at 'super': Cannot use 'super' outside of a class.
[line 2] Error at 'super': Cannot use 'super' outside of a class.
";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\super_at_top_level.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuperInClosureInInheritedMethodTest()
        {
            string expected = "A\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\super_in_closure_in_inherited_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuperInInheritedMethodTest()
        {
            string expected = "A\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\super_in_inherited_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuperInTopLevelFunctionTest()
        {
            string expected = "[line 2] Error at 'super': Cannot use 'super' outside of a class.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\super_in_top_level_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuperWithoutDotTest()
        {
            string expected = "[line 6] Error at ';': Expect '.' after 'super'.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\super_without_dot.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SuperWithoutNameTest()
        {
            string expected = "[line 5] Error at ';': Expect superclass method name.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\super\super_without_name.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThisInSuperclassMethodTest()
        {
            string expected = "a\r\nb\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\super\this_in_superclass_method.lox");

            Assert.AreEqual(expected, actual);
        }

    }
}
