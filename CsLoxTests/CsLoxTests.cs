using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace CsLoxTests
{
    [TestClass]
    public class CsLoxTests
    {
        [TestMethod]
        public void TooManyArgumentsAreRejected()
        {
            string expected = "Usage: cslox [script]\r\n";

            string actual = RunScript(@"C:\CsLox\CsLoxTests\TestScripts\extension.lox What");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IncorrectExtensionIsRejected()
        {
            string expected = "Only files with a \".lox\" extension can be read.\r\n";
            string actual = RunScript(@"C:\CsLox\CsLoxTests\TestScripts\extension.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void FileIsRun()
        {
            string expected = "Test\r\n";
            string actual = RunScript(@"C:\CsLox\CsLoxTests\TestScripts\extension.lox");

            Assert.AreEqual(expected, actual);
        }

        public static string RunScript(string script)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = @"C:\CsLox\CsLox\bin\Debug\CsLox.exe",
                Arguments = script,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            Process process = Process.Start(processStartInfo);

            string output;
            using (StreamReader reader = process.StandardOutput)
            {
                output = reader.ReadToEnd();
            }
            process.WaitForExit();

            return output;
        }
    }
}
