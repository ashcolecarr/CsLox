using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsLoxTests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void CallFunctionFieldTest()
        {
            string expected = "bar\r\n1\r\n2\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\field\call_function_field.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAndSetMethodTest()
        {
            string expected = "other\r\n1\r\nmethod\r\n2\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\field\get_and_set_method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOnBoolTest()
        {
            string expected = "Only instances have properties.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\get_on_bool.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOnClassTest()
        {
            string expected = "Only instances have properties.\r\n[line 2]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\get_on_class.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOnFunctionTest()
        {
            string expected = "Only instances have properties.\r\n[line 3]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\get_on_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOnNilTest()
        {
            string expected = "Only instances have properties.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\get_on_nil.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOnNumTest()
        {
            string expected = "Only instances have properties.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\get_on_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOnStringTest()
        {
            string expected = "Only instances have properties.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\get_on_string.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ManyTest()
        {
            string expected = @"apple
apricot
avocado
banana
bilberry
blackberry
blackcurrant
blueberry
boysenberry
cantaloupe
cherimoya
cherry
clementine
cloudberry
coconut
cranberry
currant
damson
date
dragonfruit
durian
elderberry
feijoa
fig
gooseberry
grape
grapefruit
guava
honeydew
huckleberry
jabuticaba
jackfruit
jambul
jujube
juniper
kiwifruit
kumquat
lemon
lime
longan
loquat
lychee
mandarine
mango
marionberry
melon
miracle
mulberry
nance
nectarine
olive
orange
papaya
passionfruit
peach
pear
persimmon
physalis
pineapple
plantain
plum
plumcot
pomegranate
pomelo
quince
raisin
rambutan
raspberry
redcurrant
salak
salmonberry
satsuma
strawberry
tamarillo
tamarind
tangerine
tomato
watermelon
yuzu
";
            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\field\many.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MethodTest()
        {
            string expected = "got method\r\narg\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\field\method.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MethodBindsThisTest()
        {
            string expected = "foo1\r\n1\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\field\method_binds_this.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnInstanceTest()
        {
            string expected = "bar value\r\nbaz value\r\nbar value\r\nbaz value\r\n";

            string actual = CsLoxTests.RunScript(@"C:\CsLox\CsLoxTests\TestScripts\field\on_instance.lox");

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void SetEvaluationOrderTest()
        {
            string expected = "Undefined variable 'undefined1'.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\set_evaluation_order.lox");

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void SetOnBoolTest()
        {
            string expected = "Only instances have fields.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\set_on_bool.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetOnClassTest()
        {
            string expected = "Only instances have fields.\r\n[line 2]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\set_on_class.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetOnFunctionTest()
        {
            string expected = "Only instances have fields.\r\n[line 3]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\set_on_function.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetOnNilTest()
        {
            string expected = "Only instances have fields.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\set_on_nil.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetOnNumTest()
        {
            string expected = "Only instances have fields.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\set_on_num.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetOnStringTest()
        {
            string expected = "Only instances have fields.\r\n[line 1]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\set_on_string.lox");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UndefinedTest()
        {
            string expected = "Undefined property 'bar'.\r\n[line 4]\r\n";

            string actual = CsLoxTests.RunScriptForError(@"C:\CsLox\CsLoxTests\TestScripts\field\undefined.lox");

            Assert.AreEqual(expected, actual);
        }
    }
}
