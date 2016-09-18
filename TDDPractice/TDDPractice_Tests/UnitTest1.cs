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
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata(""), "Empty strings should be zero");
        }

        [TestMethod]
        public void Test002_ValidSinglePositiveNumbers_NoDelimiters()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("0"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("10"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("20"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(333, SimpleStringParsing.StringCalculatorKata("333"), "Simple numbers should be parsed versions of themselves");
            Assert.AreEqual(1000, SimpleStringParsing.StringCalculatorKata("1000"), "Simple numbers should be parsed versions of themselves");
        }

        [TestMethod]
        public void Test003_ZeroPlusNumber_Pairs()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("0,0"), "Zero added to itself is still zero");
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("0,10"), "Zero + x is still x");
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("0,20"), "Zero + x is still x");
            Assert.AreEqual(333, SimpleStringParsing.StringCalculatorKata("0,333"), "Zero + x is still x");
            Assert.AreEqual(1000, SimpleStringParsing.StringCalculatorKata("0,1000"), "Zero + x is still x");
        }

        [TestMethod]
        public void Test004_NumberPlusZero_Pairs()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("0,0"), "Zero added to itself is still zero");
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("10,0"), "x+zero is still x");
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("20,0"), "x+zero + x is still x");
            Assert.AreEqual(333, SimpleStringParsing.StringCalculatorKata("333,0"), "x+zero + x is still x");
            Assert.AreEqual(1000, SimpleStringParsing.StringCalculatorKata("1000,0"), "x+zero + x is still x");
        }

        [TestMethod]
        public void Test005_TwoPositiveNumbers_Pairs()
        {
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1,1"));
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,2"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("10,10"));
            Assert.AreEqual(23, SimpleStringParsing.StringCalculatorKata("11,12"));
            Assert.AreEqual(230, SimpleStringParsing.StringCalculatorKata("20,210"));
            Assert.AreEqual(1010, SimpleStringParsing.StringCalculatorKata("977,33"));
        }

        [TestMethod]
        public void Test006_ZeroPlusTwoPositiveNumbers_Triples()
        {
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("0,1,1"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("0,2,10"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("0,10,20"));
            Assert.AreEqual(22, SimpleStringParsing.StringCalculatorKata("0,12,10"));
            Assert.AreEqual(211, SimpleStringParsing.StringCalculatorKata("0,210,1"));
            Assert.AreEqual(1010, SimpleStringParsing.StringCalculatorKata("0,33,977"));
        }

        [TestMethod]
        public void Test007_ThreePositiveNumbers_Triples()
        {
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1,1,0"));
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,2,0"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("10,10,0"));
            Assert.AreEqual(23, SimpleStringParsing.StringCalculatorKata("11,12,0"));
            Assert.AreEqual(230, SimpleStringParsing.StringCalculatorKata("20,210,0"));
            Assert.AreEqual(1010, SimpleStringParsing.StringCalculatorKata("977,33,0"));
        }

        [TestMethod]
        public void Test008_ThreeZeroes_Triples()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("0,0,0"));
        }

        [TestMethod]
        public void Test009_ThreePositiveNumbers_Triples()
        {
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,1,1"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("1,2,10"));
            Assert.AreEqual(40, SimpleStringParsing.StringCalculatorKata("10,10,20"));
            Assert.AreEqual(23, SimpleStringParsing.StringCalculatorKata("11,12,0"));
            Assert.AreEqual(231, SimpleStringParsing.StringCalculatorKata("20,210,1"));
            Assert.AreEqual(1090, SimpleStringParsing.StringCalculatorKata("977,33,80"));
        }

        [TestMethod]
        public void Test010_EnterSymbols_Doubles()
        {
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1\n1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("0\n1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("1\n0"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("1\n11"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("12\n1"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("10\n10"));
        }

        [TestMethod]
        public void Test011_EnterSymbols_Triples_Begin()
        {
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1\n1,1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("0\n1,1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1\n0,1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1\n1,0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("1\n11,12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("12\n1,11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("10\n10,10"));
        }

        [TestMethod]
        public void Test012_EnterSymbols_Triples_End()
        {
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("0,1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1,0\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1,1\n0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("1,11\n12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("12,1\n11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("10,10\n10"));
        }

        [TestMethod]
        public void Test013_EnterSymbols_Triples_Only()
        {
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1\n1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("0\n1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1\n0\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1\n1\n0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("1\n11\n12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("12\n1\n11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("10\n10\n10"));
        }

        [TestMethod]
        public void Test014_Delimiters_Semicolon_Doubles()
        {
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1;1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//;\n0;1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//;\n1;0"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("//;\n1;11"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("//;\n12;1"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//;\n10;10"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1\n1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//;\n0\n1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//;\n1\n0"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("//;\n1\n11"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("//;\n12\n1"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//;\n10\n10"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1,1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//;\n0,1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//;\n1,0"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("//;\n1,11"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("//;\n12,1"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//;\n10,10"));
        }

        [TestMethod]
        public void Test015_Delimiters_Semicolon_Triples()
        {
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//;\n1;1;1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n0;1;1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1;0;1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1;1;0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n1;11;12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n12;1;11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//;\n10;10;10"));

            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//;\n1,1;1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n0\n1;1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1\n0;1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1\n1;0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n1,11;12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n12\n1;11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//;\n10,10;10"));

            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//;\n1;1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n0;1,1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1;0\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1;1\n0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n1;11\n12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n12,1\n11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//;\n10;10\n10"));

            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//;\n1\n1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n0\n1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1\n0\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//;\n1\n1\n0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n1\n11\n12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//;\n12\n1\n11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//;\n10\n10\n10"));
        }

        [TestMethod]
        public void Test016_Delimiters_Star_Doubles()
        {
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1*1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//*\n0*1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//*\n1*0"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("//*\n1*11"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("//*\n12*1"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//*\n10*10"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1\n1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//*\n0\n1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//*\n1\n0"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("//*\n1\n11"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("//*\n12\n1"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//*\n10\n10"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1,1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//*\n0,1"));
            Assert.AreEqual(1, SimpleStringParsing.StringCalculatorKata("//*\n1,0"));
            Assert.AreEqual(12, SimpleStringParsing.StringCalculatorKata("//*\n1,11"));
            Assert.AreEqual(13, SimpleStringParsing.StringCalculatorKata("//*\n12,1"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//*\n10,10"));
        }

        [TestMethod]
        public void Test017_Delimiters_Star_Triples()
        {
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//*\n1*1*1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n0*1*1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1*0*1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1*1*0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n1*11*12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n12*1*11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//*\n10*10*10"));

            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//*\n1,1*1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n0\n1*1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1\n0*1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1\n1*0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n1,11*12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n12\n1*11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//*\n10,10*10"));

            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//*\n1*1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n0*1,1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1*0\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1*1\n0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n1*11\n12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n12,1\n11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//*\n10*10\n10"));

            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("//*\n1\n1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n0\n1\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1\n0\n1"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("//*\n1\n1\n0"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n1\n11\n12"));
            Assert.AreEqual(24, SimpleStringParsing.StringCalculatorKata("//*\n12\n1\n11"));
            Assert.AreEqual(30, SimpleStringParsing.StringCalculatorKata("//*\n10\n10\n10"));
        }

        private void AssertThrowsException(string expectedErrorMessage, string input)
        {
            try
            {
                SimpleStringParsing.StringCalculatorKata(input);
                Assert.Fail("Exception wasn't thrown");
            }
            catch (Exception e)
            {
                Assert.AreEqual(expectedErrorMessage, e.Message);
            }
        }

        [TestMethod]
        public void Test018_NegativeNumbers_Single()
        {
            AssertThrowsException("negatives not allowed: -0", "-0");
            AssertThrowsException("negatives not allowed: -10", "-10");
            AssertThrowsException("negatives not allowed: -20", "-20");
            AssertThrowsException("negatives not allowed: -333", "-333");
            AssertThrowsException("negatives not allowed: -4567", "-4567");
        }

        [TestMethod]
        public void Test019_NegativeNumbers_Double_start()
        {
            AssertThrowsException("negatives not allowed: -0", "-0,1");
            AssertThrowsException("negatives not allowed: -10", "-10,10");
            AssertThrowsException("negatives not allowed: -20", "-20,12");
            AssertThrowsException("negatives not allowed: -333", "-333,130");
            AssertThrowsException("negatives not allowed: -4567", "-4567,13");
        }

        [TestMethod]
        public void Test020_NegativeNumbers_Double_end()
        {
            AssertThrowsException("negatives not allowed: -0", "1,-0");
            AssertThrowsException("negatives not allowed: -10", "10,-10");
            AssertThrowsException("negatives not allowed: -20", "12,-20");
            AssertThrowsException("negatives not allowed: -333", "130,-333");
            AssertThrowsException("negatives not allowed: -4567", "13,-4567");
        }

        [TestMethod]
        public void Test021_NegativeNumbers_Double_only()
        {
            AssertThrowsException("negatives not allowed: -0,-1", "-0,-1");
            AssertThrowsException("negatives not allowed: -10,-10", "-10,-10");
            AssertThrowsException("negatives not allowed: -20,-12", "-20,-12");
            AssertThrowsException("negatives not allowed: -333,-130", "-333,-130");
            AssertThrowsException("negatives not allowed: -4567,-13", "-4567,-13");
        }

        [TestMethod]
        public void Test022_NegativeNumbers_Double_enter()
        {
            AssertThrowsException("negatives not allowed: -0", "-0\n1");
            AssertThrowsException("negatives not allowed: -10", "-10\n10");
            AssertThrowsException("negatives not allowed: -20", "-20\n12");
            AssertThrowsException("negatives not allowed: -333", "-333\n130");
            AssertThrowsException("negatives not allowed: -4567", "-4567\n13");

            AssertThrowsException("negatives not allowed: -0", "1\n-0");
            AssertThrowsException("negatives not allowed: -10", "10\n-10");
            AssertThrowsException("negatives not allowed: -20", "12\n-20");
            AssertThrowsException("negatives not allowed: -333", "130\n-333");
            AssertThrowsException("negatives not allowed: -4567", "13\n-4567");

            AssertThrowsException("negatives not allowed: -0,-1", "-0\n-1");
            AssertThrowsException("negatives not allowed: -10,-10", "-10\n-10");
            AssertThrowsException("negatives not allowed: -20,-12", "-20\n-12");
            AssertThrowsException("negatives not allowed: -333,-130", "-333\n-130");
            AssertThrowsException("negatives not allowed: -4567,-13", "-4567\n-13");
        }

        [TestMethod]
        public void Test023_NegativeNumbers_Triple_start()
        {
            AssertThrowsException("negatives not allowed: -1", "-1,1,1");
            AssertThrowsException("negatives not allowed: -0", "-0,1,1");
            AssertThrowsException("negatives not allowed: -1", "-1,0,1");
            AssertThrowsException("negatives not allowed: -1", "-1,1,0");
            AssertThrowsException("negatives not allowed: -1", "-1,11,12");
            AssertThrowsException("negatives not allowed: -12", "-12,1,11");
            AssertThrowsException("negatives not allowed: -10", "-10,10,10");
        }

        [TestMethod]
        public void Test024_NegativeNumbers_Triple_end()
        {
            AssertThrowsException("negatives not allowed: -1", "1,1,-1");
            AssertThrowsException("negatives not allowed: -1", "0,1,-1");
            AssertThrowsException("negatives not allowed: -1", "1,0,-1");
            AssertThrowsException("negatives not allowed: -0", "1,1,-0");
            AssertThrowsException("negatives not allowed: -12", "1,11,-12");
            AssertThrowsException("negatives not allowed: -11", "12,1,-11");
            AssertThrowsException("negatives not allowed: -10", "10,10,-10");
        }

        [TestMethod]
        public void Test025_NegativeNumbers_Triple_middle()
        {
            AssertThrowsException("negatives not allowed: -1", "1,-1,1");
            AssertThrowsException("negatives not allowed: -1", "0,-1,1");
            AssertThrowsException("negatives not allowed: -0", "1,-0,1");
            AssertThrowsException("negatives not allowed: -1", "1,-1,0");
            AssertThrowsException("negatives not allowed: -11", "1,-11,12");
            AssertThrowsException("negatives not allowed: -1", "12,-1,11");
            AssertThrowsException("negatives not allowed: -10", "10,-10,10");
        }

        [TestMethod]
        public void Test026_NegativeNumbers_Triple_starttwo()
        {
            AssertThrowsException("negatives not allowed: -1,-1", "-1,-1,1");
            AssertThrowsException("negatives not allowed: -0,-1", "-0,-1,1");
            AssertThrowsException("negatives not allowed: -1,-0", "-1,-0,1");
            AssertThrowsException("negatives not allowed: -1,-1", "-1,-1,0");
            AssertThrowsException("negatives not allowed: -1,-11", "-1,-11,12");
            AssertThrowsException("negatives not allowed: -12,-1", "-12,-1,11");
            AssertThrowsException("negatives not allowed: -10,-10", "-10,-10,10");
        }

        [TestMethod]
        public void Test027_NegativeNumbers_Triple_endtwo()
        {
            AssertThrowsException("negatives not allowed: -1,-1", "1,-1,-1");
            AssertThrowsException("negatives not allowed: -1,-1", "0,-1,-1");
            AssertThrowsException("negatives not allowed: -0,-1", "1,-0,-1");
            AssertThrowsException("negatives not allowed: -1,-0", "1,-1,-0");
            AssertThrowsException("negatives not allowed: -11,-12", "1,-11,-12");
            AssertThrowsException("negatives not allowed: -1,-11", "12,-1,-11");
            AssertThrowsException("negatives not allowed: -10,-10", "10,-10,-10");
        }

        [TestMethod]
        public void Test028_NegativeNumbers_Triple_ends()
        {
            AssertThrowsException("negatives not allowed: -1,-1", "-1,1,-1");
            AssertThrowsException("negatives not allowed: -0,-1", "-0,1,-1");
            AssertThrowsException("negatives not allowed: -1,-1", "-1,0,-1");
            AssertThrowsException("negatives not allowed: -1,-0", "-1,1,-0");
            AssertThrowsException("negatives not allowed: -1,-12", "-1,11,-12");
            AssertThrowsException("negatives not allowed: -12,-11", "-12,1,-11");
            AssertThrowsException("negatives not allowed: -10,-10", "-10,10,-10");
        }

        [TestMethod]
        public void Test029_NegativeNumbers_Triple_all()
        {
            AssertThrowsException("negatives not allowed: -1,-1,-1", "-1,-1,-1");
            AssertThrowsException("negatives not allowed: -0,-1,-1", "-0,-1,-1");
            AssertThrowsException("negatives not allowed: -1,-0,-1", "-1,-0,-1");
            AssertThrowsException("negatives not allowed: -1,-1,-0", "-1,-1,-0");
            AssertThrowsException("negatives not allowed: -1,-11,-12", "-1,-11,-12");
            AssertThrowsException("negatives not allowed: -12,-1,-11", "-12,-1,-11");
            AssertThrowsException("negatives not allowed: -10,-10,-10", "-10,-10,-10");
        }

        [TestMethod]
        public void Test030_NegativeNumbers_Triple_enter()
        {
            AssertThrowsException("negatives not allowed: -1", "-1\n1,1");
            AssertThrowsException("negatives not allowed: -0", "-0,1\n1");
            AssertThrowsException("negatives not allowed: -1", "-1\n0\n1");
            AssertThrowsException("negatives not allowed: -1", "-1\n1,0");
            AssertThrowsException("negatives not allowed: -1", "-1,11\n12");
            AssertThrowsException("negatives not allowed: -12", "-12\n1\n11");
            AssertThrowsException("negatives not allowed: -10", "-10,10\n10");

            AssertThrowsException("negatives not allowed: -1", "1\n1,-1");
            AssertThrowsException("negatives not allowed: -1", "0,1\n-1");
            AssertThrowsException("negatives not allowed: -1", "1\n0\n-1");
            AssertThrowsException("negatives not allowed: -0", "1\n1,-0");
            AssertThrowsException("negatives not allowed: -12", "1,11\n-12");
            AssertThrowsException("negatives not allowed: -11", "12\n1\n-11");
            AssertThrowsException("negatives not allowed: -10", "10,10\n-10");

            AssertThrowsException("negatives not allowed: -1", "1\n-1,1");
            AssertThrowsException("negatives not allowed: -1", "0,-1\n1");
            AssertThrowsException("negatives not allowed: -0", "1\n-0\n1");
            AssertThrowsException("negatives not allowed: -1", "1\n-1,0");
            AssertThrowsException("negatives not allowed: -11", "1,-11\n12");
            AssertThrowsException("negatives not allowed: -1", "12\n-1\n11");
            AssertThrowsException("negatives not allowed: -10", "10,-10\n10");

            AssertThrowsException("negatives not allowed: -1,-1", "-1\n-1,1");
            AssertThrowsException("negatives not allowed: -0,-1", "-0,-1\n1");
            AssertThrowsException("negatives not allowed: -1,-0", "-1\n-0\n1");
            AssertThrowsException("negatives not allowed: -1,-1", "-1\n-1,0");
            AssertThrowsException("negatives not allowed: -1,-11", "-1,-11\n12");
            AssertThrowsException("negatives not allowed: -12,-1", "-12\n-1\n11");
            AssertThrowsException("negatives not allowed: -10,-10", "-10,-10\n10");

            AssertThrowsException("negatives not allowed: -1,-1", "1\n-1,-1");
            AssertThrowsException("negatives not allowed: -1,-1", "0,-1\n-1");
            AssertThrowsException("negatives not allowed: -0,-1", "1\n-0\n-1");
            AssertThrowsException("negatives not allowed: -1,-0", "1\n-1,-0");
            AssertThrowsException("negatives not allowed: -11,-12", "1,-11\n-12");
            AssertThrowsException("negatives not allowed: -1,-11", "12\n-1\n-11");
            AssertThrowsException("negatives not allowed: -10,-10", "10,-10\n-10");

            AssertThrowsException("negatives not allowed: -1,-1", "-1\n1,-1");
            AssertThrowsException("negatives not allowed: -0,-1", "-0,1\n-1");
            AssertThrowsException("negatives not allowed: -1,-1", "-1\n0\n-1");
            AssertThrowsException("negatives not allowed: -1,-0", "-1\n1,-0");
            AssertThrowsException("negatives not allowed: -1,-12", "-1,11\n-12");
            AssertThrowsException("negatives not allowed: -12,-11", "-12\n1\n-11");
            AssertThrowsException("negatives not allowed: -10,-10", "-10,10\n-10");

            AssertThrowsException("negatives not allowed: -1,-1,-1", "-1\n-1,-1");
            AssertThrowsException("negatives not allowed: -0,-1,-1", "-0,-1\n-1");
            AssertThrowsException("negatives not allowed: -1,-0,-1", "-1\n-0\n-1");
            AssertThrowsException("negatives not allowed: -1,-1,-0", "-1\n-1,-0");
            AssertThrowsException("negatives not allowed: -1,-11,-12", "-1,-11\n-12");
            AssertThrowsException("negatives not allowed: -12,-1,-11", "-12\n-1\n-11");
            AssertThrowsException("negatives not allowed: -10,-10,-10", "-10,-10\n-10");
        }

        [TestMethod]
        public void Test031_NegativeNumbers_Double_delimiters()
        {
            AssertThrowsException("negatives not allowed: -0", "//;\n-0;1");
            AssertThrowsException("negatives not allowed: -10", "//;\n-10;10");
            AssertThrowsException("negatives not allowed: -20", "//;\n-20;12");
            AssertThrowsException("negatives not allowed: -333", "//;\n-333;130");
            AssertThrowsException("negatives not allowed: -4567", "//;\n-4567;13");

            AssertThrowsException("negatives not allowed: -0", "//;\n1;-0");
            AssertThrowsException("negatives not allowed: -10", "//;\n10;-10");
            AssertThrowsException("negatives not allowed: -20", "//;\n12;-20");
            AssertThrowsException("negatives not allowed: -333", "//;\n130;-333");
            AssertThrowsException("negatives not allowed: -4567", "//;\n13;-4567");

            AssertThrowsException("negatives not allowed: -0,-1", "//;\n-0;-1");
            AssertThrowsException("negatives not allowed: -10,-10", "//;\n-10;-10");
            AssertThrowsException("negatives not allowed: -20,-12", "//;\n-20;-12");
            AssertThrowsException("negatives not allowed: -333,-130", "//;\n-333;-130");
            AssertThrowsException("negatives not allowed: -4567,-13", "//;\n-4567;-13");
        }

        [TestMethod]
        public void Test032_NegativeNumbers_Triples_delimiters()
        {
            AssertThrowsException("negatives not allowed: -1", "//;\n-1;1,1");
            AssertThrowsException("negatives not allowed: -0", "//;\n-0,1;1");
            AssertThrowsException("negatives not allowed: -1", "//;\n-1;0;1");
            AssertThrowsException("negatives not allowed: -1", "//;\n-1;1,0");
            AssertThrowsException("negatives not allowed: -1", "//;\n-1,11;12");
            AssertThrowsException("negatives not allowed: -12", "//;\n-12;1;11");
            AssertThrowsException("negatives not allowed: -10", "//;\n-10,10;10");

            AssertThrowsException("negatives not allowed: -1", "//;\n1\n1;-1");
            AssertThrowsException("negatives not allowed: -1", "//;\n0;1\n-1");
            AssertThrowsException("negatives not allowed: -1", "//;\n1;0;-1");
            AssertThrowsException("negatives not allowed: -0", "//;\n1\n1;-0");
            AssertThrowsException("negatives not allowed: -12", "//;\n1;11\n-12");
            AssertThrowsException("negatives not allowed: -11", "//;\n12;1;-11");
            AssertThrowsException("negatives not allowed: -10", "//;\n10;10\n-10");

            AssertThrowsException("negatives not allowed: -1", "//;\n1;-1,1");
            AssertThrowsException("negatives not allowed: -1", "//;\n0,-1;1");
            AssertThrowsException("negatives not allowed: -0", "//;\n1;-0;1");
            AssertThrowsException("negatives not allowed: -1", "//;\n1;-1,0");
            AssertThrowsException("negatives not allowed: -11", "//;\n1,-11;12");
            AssertThrowsException("negatives not allowed: -1", "//;\n12;-1;11");
            AssertThrowsException("negatives not allowed: -10", "//;\n10,-10;10");

            AssertThrowsException("negatives not allowed: -1,-1", "//;\n-1\n-1;1");
            AssertThrowsException("negatives not allowed: -0,-1", "//;\n-0;-1\n1");
            AssertThrowsException("negatives not allowed: -1,-0", "//;\n-1;-0;1");
            AssertThrowsException("negatives not allowed: -1,-1", "//;\n-1\n-1;0");
            AssertThrowsException("negatives not allowed: -1,-11", "//;\n-1;-11\n12");
            AssertThrowsException("negatives not allowed: -12,-1", "//;\n-12;-1;11");
            AssertThrowsException("negatives not allowed: -10,-10", "//;\n-10;-10\n10");

            AssertThrowsException("negatives not allowed: -1,-1", "//;\n1;-1,-1");
            AssertThrowsException("negatives not allowed: -1,-1", "//;\n0,-1;-1");
            AssertThrowsException("negatives not allowed: -0,-1", "//;\n1;-0\n-1");
            AssertThrowsException("negatives not allowed: -1,-0", "//;\n1;-1,-0");
            AssertThrowsException("negatives not allowed: -11,-12", "//;\n1,-11;-12");
            AssertThrowsException("negatives not allowed: -1,-11", "//;\n12;-1;-11");
            AssertThrowsException("negatives not allowed: -10,-10", "//;\n10,-10;-10");

            AssertThrowsException("negatives not allowed: -1,-1", "//;\n-1\n1;-1");
            AssertThrowsException("negatives not allowed: -0,-1", "//;\n-0;1\n-1");
            AssertThrowsException("negatives not allowed: -1,-1", "//;\n-1;0;-1");
            AssertThrowsException("negatives not allowed: -1,-0", "//;\n-1\n1;-0");
            AssertThrowsException("negatives not allowed: -1,-12", "//;\n-1;11\n-12");
            AssertThrowsException("negatives not allowed: -12,-11", "//;\n-12;1;-11");
            AssertThrowsException("negatives not allowed: -10,-10", "//;\n-10;10\n-10");

            AssertThrowsException("negatives not allowed: -1,-1,-1", "//;\n-1;-1,-1");
            AssertThrowsException("negatives not allowed: -0,-1,-1", "//;\n-0,-1;-1");
            AssertThrowsException("negatives not allowed: -1,-0,-1", "//;\n-1;-0;-1");
            AssertThrowsException("negatives not allowed: -1,-1,-0", "//;\n-1;-1,-0");
            AssertThrowsException("negatives not allowed: -1,-11,-12", "//;\n-1,-11;-12");
            AssertThrowsException("negatives not allowed: -12,-1,-11", "//;\n-12;-1;-11");
            AssertThrowsException("negatives not allowed: -10,-10,-10", "//;\n-10,-10;-10");
        }

        [TestMethod]
        public void Test033_Exclude1001()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("1001,0"));
            Assert.AreEqual(1000, SimpleStringParsing.StringCalculatorKata("1000,0"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("1001\n1,1"));
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,1001,2"));
            Assert.AreEqual(111, SimpleStringParsing.StringCalculatorKata("1001\n111,1001"));
            Assert.AreEqual(116, SimpleStringParsing.StringCalculatorKata("1001\n111,1001,1001,1001,5"));
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("//;\n1001;10"));
        }

        [TestMethod]
        public void Test034_ExcludeAllGreaterThan1000()
        {
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("945945,0"));
            Assert.AreEqual(2, SimpleStringParsing.StringCalculatorKata("4653847\n1,1"));
            Assert.AreEqual(3, SimpleStringParsing.StringCalculatorKata("1,45545,2"));
            Assert.AreEqual(111, SimpleStringParsing.StringCalculatorKata("4564\n111,4540"));
            Assert.AreEqual(116, SimpleStringParsing.StringCalculatorKata("45684\n111,4448,4864,4444,5"));
            Assert.AreEqual(10, SimpleStringParsing.StringCalculatorKata("//;\n44445;10"));
        }

        [TestMethod]
        public void Test035_CustomDelimiters1_TripleStars()
        {
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//[***]\n10***10"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//[***]\n1001***20"));
            Assert.AreEqual(22, SimpleStringParsing.StringCalculatorKata("//[***]\n1001***20***2"));
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("//[***]\n1001***1001,0"));
        }

        [TestMethod]
        public void Test036_CustomDelimiters2_DoublePlus()
        {
            Assert.AreEqual(21, SimpleStringParsing.StringCalculatorKata("//[++]\n11++10"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//[++]\n1001++20"));
            Assert.AreEqual(22, SimpleStringParsing.StringCalculatorKata("//[++]\n1001++20++2"));
            Assert.AreEqual(0, SimpleStringParsing.StringCalculatorKata("//[++]\n1001++1001,0"));
        }

        [TestMethod]
        public void Test037_CustomDelimiters3_MixedWithNumbers()
        {
            //Nothing says a delimiter can't contain a number, so some of these do
            Assert.AreEqual(28, SimpleStringParsing.StringCalculatorKata("//[*6a]\n11*6a17"));
            Assert.AreEqual(20, SimpleStringParsing.StringCalculatorKata("//[,,]\n1001,,20"));
            Assert.AreEqual(22, SimpleStringParsing.StringCalculatorKata("//[(9]\n1001(920,2"));
            Assert.AreEqual(106, SimpleStringParsing.StringCalculatorKata("//[-666-]\n1501-666-101,5"));
        }

        [TestMethod]
        public void Test038_TwoCustomLength1Delimiters()
        {
            Assert.AreEqual(6, SimpleStringParsing.StringCalculatorKata("//[+][*]\n1+2+3"));
            Assert.AreEqual(9, SimpleStringParsing.StringCalculatorKata("//[+][*]\n1*2+6"));
            Assert.AreEqual(17, SimpleStringParsing.StringCalculatorKata("//[_][.]\n1.2_6,8"));
            Assert.AreEqual(7, SimpleStringParsing.StringCalculatorKata("//[_][.]\n1.10000_6"));
        }

        [TestMethod]
        public void Test039_MultipleCustomLength1Delimiters()
        {
            //adding unnused deliters to previous test's cases to detect croken parsing
            Assert.AreEqual(6, SimpleStringParsing.StringCalculatorKata("//[+][*][_]\n1+2+3"));
            Assert.AreEqual(9, SimpleStringParsing.StringCalculatorKata("//[_][+][*]\n1*2+6"));
            Assert.AreEqual(17, SimpleStringParsing.StringCalculatorKata("//[_][=][.]\n1.2_6,8"));
            Assert.AreEqual(7, SimpleStringParsing.StringCalculatorKata("//[+][_][.]\n1.10000_6"));

            //using all delimeters
            Assert.AreEqual(1007, SimpleStringParsing.StringCalculatorKata("//[+][*][_][)]\n1)2_3*1+1000"));
            Assert.AreEqual(5, SimpleStringParsing.StringCalculatorKata("//[_][)][+][*]\n1_1)1+1*1"));
            Assert.AreEqual(308, SimpleStringParsing.StringCalculatorKata("//[)][_][=][.]\n2)2_2=2.100.200.1001"));
            Assert.AreEqual(45, SimpleStringParsing.StringCalculatorKata("//[+][)][_][.]\n1+2,3)4,5\n6_7.8,9"));
        }
    }
}
