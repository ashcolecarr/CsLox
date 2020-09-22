using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class PrintTests
    {
        [TestMethod]
        public void MissingArgumentTest()
        {
            string expected = "[line 2] Error at ';': Expect expression.\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\print\missing_argument.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
