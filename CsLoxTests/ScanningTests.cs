using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class ScanningTests
    {
        [TestMethod, Ignore]
        public void IdentifiersTest()
        {
            string expected = @"IDENTIFIER andy 
IDENTIFIER formless 
IDENTIFIER fo 
IDENTIFIER _ 
IDENTIFIER _123 
IDENTIFIER _abc 
IDENTIFIER ab123 
IDENTIFIER abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_ 
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\scanning\identifiers.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void KeywordsTest()
        {
            string expected = @"AND and 
CLASS class 
ELSE else 
FALSE false 
FOR for 
FUN fun 
IF if 
NIL nil 
OR or 
RETURN return 
SUPER super 
THIS this 
TRUE true 
VAR var 
WHILE while 
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\scanning\keywords.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void NumbersTest()
        {
            string expected = @"NUMBER 123 123
NUMBER 123.456 123.456
DOT . 
NUMBER 456 456
NUMBER 123 123
DOT . 
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\scanning\numbers.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void PunctuatorsTest()
        {
            string expected = @"LEFT_PAREN ( 
RIGHT_PAREN ) 
LEFT_BRACE { 
RIGHT_BRACE } 
SEMICOLON ; 
COMMA , 
PLUS + 
MINUS - 
STAR * 
BANG_EQUAL != 
EQUAL_EQUAL == 
LESS_EQUAL <= 
GREATER_EQUAL >= 
BANG_EQUAL != 
LESS < 
GREATER > 
SLASH / 
DOT . 
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\scanning\punctuators.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void StringsTest()
        {
            string expected = @"STRING """" 
STRING ""string"" string
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\scanning\strings.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, Ignore]
        public void WhitespaceTest()
        {
            string expected = @"IDENTIFIER space 
IDENTIFIER tabs 
IDENTIFIER newlines 
IDENTIFIER end 
EOF  
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\scanning\whitespace.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
