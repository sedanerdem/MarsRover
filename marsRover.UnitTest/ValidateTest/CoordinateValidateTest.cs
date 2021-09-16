using Microsoft.VisualStudio.TestTools.UnitTesting;
using marsRover.Validation;

namespace marsRover.UnitTest.ValidateTest
{
    [TestClass]
    public class CoordinateValidateTest
    {
        [TestMethod]
        public void CoordinateValidationTest()
        {
            string upperRight = "5 5";
            Assert.AreEqual(true, new CoordinateValidation(upperRight).IsValid());
        }

        [TestMethod]
        public void CoordinateValidationTestError()
        {
            string upperRight = "5 -1";
            Assert.AreEqual(false, new CoordinateValidation(upperRight).IsValid());
        }
    }
}