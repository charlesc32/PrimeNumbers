using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PrimeNumbersTests
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetExistingPrimes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PrimeNumbers.exe")]
        public void GetExistingPrimesTest()
        {
            Program_Accessor.foundPrimes = new System.Collections.Generic.List<uint>() { 2, 3, 5, 7 };
            uint limit = 10;
            string expected = "2 3 5 7";
            string actual;
            actual = Program_Accessor.GetExistingPrimes(limit);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsPrime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PrimeNumbers.exe")]
        public void IsPrimeTest()
        {
            Dictionary<uint, bool> inputExpected = new Dictionary<uint, bool>() { { 1, false }, { 2, true }, { 3, true }, { 4, false }, { 5, true }, { 6, false }, { 5000, false }, { 5003, true } };
            foreach (var item in inputExpected)
            {
                bool actual = Program_Accessor.IsPrime(item.Key);
                Assert.AreEqual(item.Value, actual, "Failed for: " + item.Key);
            }
        }

        /// <summary>
        ///A test for GetFinalOutput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PrimeNumbers.exe")]
        public void GetFinalOutputTest()
        {
            List<uint> inputs = new List<uint>() { 10, 20, 100 };
            string expected = "2,3,5,7" + Environment.NewLine + 
                              "2,3,5,7,11,13,17,19" + Environment.NewLine +
                              "2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97";
            string actual;
            actual = Program_Accessor.GetFinalOutput(inputs);
            Assert.AreEqual(expected, actual);
        }
    }
}
