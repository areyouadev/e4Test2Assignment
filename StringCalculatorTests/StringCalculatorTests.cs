namespace StringCalculatorTests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class StringCalculatorTests
    {
        #region TestSetup
        
        StringCalculator.StringCalculator  calculator;

        [SetUp]
        public void setup()
        {
            calculator = new StringCalculator.StringCalculator();
        }

        #endregion TestSetup

        #region Tests

        [Test]
        public void Add_Empty_String()
        {
            var result = calculator.Add("");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_Single_Number_Returns_SameNumber()
        {
            var result = calculator.Add("1");
            Assert.AreEqual(1, result);
        }
        [Test]
        public void Add_Two_Numbers_Returns_Addition()
        {
            var result = calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_Three_Numbers_Returns_Addition()
        {
            var result = calculator.Add("10,30,40");
            Assert.AreEqual(80, result);
        }

        [Test]
        public void Add_Newline_Zero()
        {
            var result = calculator.Add("\n");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_NewLine_As_Separator()
        {
            var result = calculator.Add("1\n2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_DifferentDelimiter_UsedToParseTheSum()
        {
            var result = calculator.Add("//A\n1A2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_DifferentDelimiter_UsedToParseTheSum2()
        {
            var result = calculator.Add("//B\n1B2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_Negative_Throws_Exception()
        {
            Assert.That(() => calculator.Add("-1"), Throws.TypeOf<Exception>());
        }

        [Test]
        public void Add_Multiple_Negative_Throws_Exception()
        {
            Assert.That(() => calculator.Add("-1,-2"), Throws.TypeOf<Exception>());
        }

        [Test]
        public void Add_NegativeAndpositive_Throws_Exception()
        {
            Assert.That(() => calculator.Add("-1,2"), Throws.TypeOf<Exception>());
        }

        [Test]
        public void Add_DelimiterslongerThanOneChar_Accepted()
        {
            var result = calculator.Add("//AAA\n1AAA2AAA3");
            Assert.AreEqual(6, result);
        }

        #endregion Tests
    }
}