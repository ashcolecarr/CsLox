using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class ClosureTests
    {
        [TestMethod]
        public void AssignToClosureTest()
        {
            string expected = "local\r\nafter f\r\nafter f\r\nafter g\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\assign_to_closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssignToShadowedLaterTest()
        {
            string expected = "inner\r\nassigned\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\assign_to_shadowed_later.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CloseOverFunctionParameterTest()
        {
            string expected = "param\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\close_over_function_parameter.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CloseOverLaterVariableTest()
        {
            string expected = "b\r\na\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\close_over_later_variable.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CloseOverMethodParameterTest()
        {
            string expected = "param\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\close_over_method_parameter.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClosedClosureInFunctionTest()
        {
            string expected = "local\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\closed_closure_in_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NestedClosureTest()
        {
            string expected = "a\r\nb\r\nc\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\nested_closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OpenClosureInFunctionTest()
        {
            string expected = "local\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\open_closure_in_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReferenceClosureMultipleTimesTest()
        {
            string expected = "a\r\na\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\reference_closure_multiple_times.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReuseClosureSlotTest()
        {
            string expected = "a\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\reuse_closure_slot.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShadowClosureWithLocalTest()
        {
            string expected = "closure\r\nshadow\r\nclosure\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\shadow_closure_with_local.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnusedClosureTest()
        {
            string expected = "ok\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\unused_closure.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnusedLaterClosureTest()
        {
            string expected = "a\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\closure\unused_later_closure.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
