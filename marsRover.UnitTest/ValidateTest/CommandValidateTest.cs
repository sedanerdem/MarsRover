using Microsoft.VisualStudio.TestTools.UnitTesting;
using marsRover.Validation;

namespace marsRover.UnitTest.ValidateTest
{
    [TestClass]
    public class CommandValidateTest
    {
        [TestMethod]
        public void CommandValidationTest()
        {
            string command = "LMLMLM";
            Assert.AreEqual(true, new CommandValidation(command).IsValid());
        }

        [TestMethod]
        public void CommandValidationTestError()
        {
            string command = "LMLALM";
            Assert.AreEqual(false, new CommandValidation(command).IsValid());
        }
    }
}
