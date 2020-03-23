using NUnit.Framework;
using StudentsManagament.Helpers;

namespace StudentsManagement.Tests
{
    public class CommandValidatorTests
    {
        private CommandValidator _commandValidator;

        [SetUp]
        public void Setup()
        {
            _commandValidator = new CommandValidator();
        }

        [TestCase("name", true)]
        public void IsVerifyParameter_ReturnTrue_WithNameParameter(string parameter, bool expectedResult)
        {
            bool result = _commandValidator.VerifyParameter(parameter);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("type", true)]
        public void IsVerifyParameter_ReturnTrue_WithTypeParameter(string parameter, bool expectedResult)
        {
            bool result = _commandValidator.VerifyParameter(parameter);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("gender", true)]
        public void IsVerifyParameter_ReturnTru_WithGenderParameter(string parameter, bool expectedResult)
        {
            bool result = _commandValidator.VerifyParameter(parameter);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("color", false)]
        public void IsVerifyParameter_ReturnFalse_WithInvalidParameter(string parameter, bool expectedResult)
        {
            bool result = _commandValidator.VerifyParameter(parameter);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("name=Luke", true)]
        public void IsVerifyCorrectFormat_ReturnTrue_WithCorrectValues(string parameter, bool expectedResult)
        {
            bool result = _commandValidator.VerifyCorrectFormat(parameter);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("names=Sarah", false)]
        public void IsVerifyCorrectFormat_ReturnFalse_WithNullParameterValues(string parameter, bool expectedResult)
        {
            bool result = _commandValidator.VerifyCorrectFormat(parameter);
            Assert.AreEqual(expectedResult, result);
        }

        //GetCommandParameter
        [TestCase("type=kinder", "type")]
        public void IsGetCommandParameter_ReturnType_WithCorrectValues(string parameter, string expectedResult)
        {
            string result = _commandValidator.GetCommandParameter(parameter);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("type=kinder", "kinder")]
        public void IsGetCommandParameterValue_ReturnKinder_WithCorrectValues(string parameter, string expectedResult)
        {
            string result = _commandValidator.GetCommandParameterValue(parameter);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
