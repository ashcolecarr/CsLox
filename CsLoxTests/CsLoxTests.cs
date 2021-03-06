﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace CsLoxTests
{
    [TestClass]
    public class CsLoxTests
    {
        [TestMethod]
        public void TooManyArgumentsAreRejectedTest()
        {
            string expected = "Usage: cslox [script]\r\n";

            string actual = RunScript(@"C:\CsLox\CsLoxTests\TestScripts\extension.lox What");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IncorrectExtensionIsRejectedTest()
        {
            string expected = "Only files with a \".lox\" extension can be read.\r\n";

            string actual = RunScript(@"C:\CsLox\CsLoxTests\TestScripts\extension.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void FileIsRunTest()
        {
            string expected = "Test\r\n";

            string actual = RunScript(@"C:\CsLox\CsLoxTests\TestScripts\extension.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrecedenceTest()
        {
            string expected = @"14
8
4
0
True
True
True
True
0
0
0
0
4
";

            string actual = RunScript(@"C:\CsLox\CsLoxTests\TestScripts\precedence.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnexpectedCharacterTest()
        {
            string expected = "[line 3] Error: Unexpected character.\r\n[line 3] Error at 'b': Expect ')' after arguments.\r\n";

            string actual = RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\unexpected_character.lox");

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

        public static string RunScriptForError(string script)
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
            using (StreamReader reader = process.StandardError)
            {
                output = reader.ReadToEnd();
            }
            process.WaitForExit();

            return output;
        }
    }
}
