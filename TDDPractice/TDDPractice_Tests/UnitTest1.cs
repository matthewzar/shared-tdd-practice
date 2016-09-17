using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPractice;

namespace TDDPractice_Tests
{
    [TestClass]
    public class UnitTest1
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
}
