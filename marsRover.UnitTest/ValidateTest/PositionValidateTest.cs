using Microsoft.VisualStudio.TestTools.UnitTesting;
using marsRover.Validation;

namespace marsRover.UnitTest.ValidateTest
{
    [TestClass]
    public class PositionValidateTest
    {
        [TestMethod]
        public void PositionValidationTest()
        {
            string position = "1 5 E";

            int Width = 5;
            int Height = 5;
            Assert.AreEqual(true, new PositionValidation(position, Width, Height).IsValid());
        }

        [TestMethod]
        public void PositionValidationTestError()
        {
            string position = "2 12 N";
            int Width = 5;
            int Height = 5;
            Assert.AreEqual(false, new PositionValidation(position, Width, Height).IsValid());
        }
    }
}
