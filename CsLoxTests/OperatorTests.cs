using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void AddTest()
        {
            string expected = "579\r\nstring\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\add.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBoolNilTest()
        {
            string expected = "Right-hand operand cannot be nil.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\add_bool_nil.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBoolNumTest()
        {
            string expected = "Trues\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\add_bool_string.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNilNilTest()
        {
            string expected = "Left-hand operand cannot be nil.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\add_nil_nil.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNumNilTest()
        {
            string expected = "Right-hand operand cannot be nil.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\add_num_nil.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddStringNilTest()
        {
            string expected = "Right-hand operand cannot be nil.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\add_string_nil.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ComparisonTest()
        {
            string expected = @"True
False
False
True
True
False
False
False
True
False
True
True
False
False
False
False
True
True
True
True
"; 

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\comparison.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            string expected = "4\r\n1\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\divide.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideByZero()
        {
            string expected = "Cannot divide by zero.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\divide_by_zero.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideNonnumNumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\divide_nonnum_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideNumNonnumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\divide_num_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsTest()
        {
            string expected = @"True
True
False
True
False
True
False
False
False
False
"; 

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\equals.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GreaterNonnumNumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\greater_nonnum_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GreaterNumNonnumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\greater_num_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GreaterOrEqualNonnumNumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\greater_or_equal_nonnum_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GreaterOrEqualNumNonnumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\greater_or_equal_num_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LessNonnumNumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\less_nonnum_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LessNumNonnumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\less_num_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LessOrEqualNonnumNumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\less_or_equal_nonnum_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LessOrEqualNumNonnumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\less_or_equal_num_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            string expected = "15\r\n3.702\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\multiply.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyNonnumNumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\multiply_nonnum_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplyNumNonnumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\multiply_num_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegateTest()
        {
            string expected = "-3\r\n3\r\n-3\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\negate.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegateNonnumTest()
        {
            string expected = "Operand must be a number.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\negate_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void NotTest()
        {
            string expected = @"False
True
True
False
False
True
False
False
"; 

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\not.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void NotEqualsTest()
        {
            string expected = @"False
False
True
False
True
False
True
True
True
True
"; 

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\not_equals.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractTest()
        {
            string expected = "1\r\n0\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\subtract.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractNonnumNumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\subtract_nonnum_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractNumNonnumTest()
        {
            string expected = "Operands must be numbers.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\subtract_num_nonnum.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TernaryTest()
        {
            string expected = "yes\r\nno\r\n2\r\n1\r\ngreater\r\nless\r\nno\r\nyes\r\nno\r\nwhat\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\operator\ternary.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TernaryMissingThenTest()
        {
            string expected = "[line 2] Error at ':': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\ternary_missing_then.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TernaryMissingElseTest()
        {
            string expected = "[line 2] Error at ';': Expect ':' after expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\operator\ternary_missing_else.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
