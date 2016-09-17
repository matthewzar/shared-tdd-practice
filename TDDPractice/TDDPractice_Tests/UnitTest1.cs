using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPractice;

namespace TDDPractice_Tests
{
    [TestClass]
    public class SimpleStringParsing_StringToInt_Tests
    {
        [TestMethod]
        public void SimpleBaseCases()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringToInt("0"), "Zero basecase");
            Assert.AreEqual(10, SimpleStringParsing.StringToInt("10"), "Two digit test: 10");
            Assert.AreEqual(100, SimpleStringParsing.StringToInt("100"), "Three digit test: 100");
            Assert.AreEqual(8, SimpleStringParsing.StringToInt("8"), "One digit test: 8");
        }

        [TestMethod]
        public void NegativeNumCases()
        {
            Assert.AreEqual(-1, SimpleStringParsing.StringToInt("-1"));
            Assert.AreEqual(-10, SimpleStringParsing.StringToInt("-10"));
            Assert.AreEqual(-100, SimpleStringParsing.StringToInt("-100"));
            Assert.AreEqual(-8, SimpleStringParsing.StringToInt("-8"));
        }

        [TestMethod]
        public void InvalidStrings()
        {
            try
            {
                SimpleStringParsing.StringToInt("a");
                Assert.Fail("Invalid test string, should show exception");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }

    [TestClass]
    public class SimpleStringParsing_StringCalculatorKata_Tests
    {
        [TestMethod]
        public void Test001_EmptyStringIsZero()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata(""), "Empty strings shouls be zero");
        }

        [TestMethod]
        public void Test002_ValidSinglePositiveNumbers_NoDelimiters()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("0"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("10"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("20"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(333, SimpleStringParsing.StringCalculatorKata("333"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(4567, SimpleStringParsing.StringCalculatorKata("4567"), "Simple numbers should be parsed versions of themselves");
        }

        [TestMethod]
        public void Test003_ZeroPlusNumber_Pairs()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("0,0"), "Zero added to itself is still zero");
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("0,10"), "Zero + x is still x");
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("0,20"), "Zero + x is still x");
            Assert.AreEqual(333, SimpleStringParsing.StringCalculatorKata("0,333"), "Zero + x is still x");
            Assert.AreEqual(4567, SimpleStringParsing.StringCalculatorKata("0,4567"), "Zero + x is still x");
        }

        [TestMethod]
        public void Test004_NumberPlusZero_Pairs()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("0,0"), "Zero added to itself is still zero");
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("10,0"), "x+zero is still x");
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("20,0"), "x+zero + x is still x");
            Assert.AreEqual(333, SimpleStringParsing.StringCalculatorKata("33,0"), "x+zero + x is still x");
            Assert.AreEqual(4567, SimpleStringParsing.StringCalculatorKata("4567,0"), "x+zero + x is still x");
        }

        [TestMethod]
        public void Test005_TwoPositiveNumbers_Pairs()
        {
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1,1"));
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,2"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("10,10"));
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("11,12"));
            Assert.AreEqual(210, SimpleStringParsing.StringCalculatorKata("20,210"));
            Assert.AreEqual(6633, SimpleStringParsing.StringCalculatorKata("6600,33"));
        }

        [TestMethod]
        public void Test006_ThreePositiveNumbers_Triples()
        {
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,1,1"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("1,2,10"));
            Assert.AreEqual(40, SimpleStringParsing.StringCalculatorKata("10,10,20"));
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("11,12,0"));
            Assert.AreEqual(211, SimpleStringParsing.StringCalculatorKata("20,210,1"));
            Assert.AreEqual(106633, SimpleStringParsing.StringCalculatorKata("6600,33,100000"));
        }
    }
}
