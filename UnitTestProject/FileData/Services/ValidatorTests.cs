using FileData.Interfaces;
using FileData.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTestProject.FileData.Services
{
    [TestFixture]
    public class ValidatorTests
    {
        private Mock<ILogger<Validator>> _loggerMock;
        private IValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<Validator>>();
            _validator = new Validator(_loggerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _validator = null;
        }

        [Test]
        public void GivenIPassNoArgument_ThenExceptionIsThrown()
        {
            //Arrange
            string[] args = { };

            //Act & Assert
            Assert.Throws<Exception>(() => _validator.ValidateConsoleArguments(args));
        }

        [Test]
        public void GivenIPassOnlyOneArgument_ThenExceptionIsThrown()
        {
            //Arrange
            string[] args = { "-v" };

            //Act & Assert
            Assert.Throws<Exception>(() => _validator.ValidateConsoleArguments(args));
        }

        [TestCase("-a")]
        [TestCase("-abc")]
        public void GivenFirstArgumentIsInvalid_ThenExceptionIsThrown(string firstArgument)
        {
            //Arrange
            string[] args = { firstArgument, "C:/test.txt" };

            //Act & Assert
            Assert.Throws<Exception>(() => _validator.ValidateConsoleArguments(args));
        }

        [TestCase("-v")]
        [TestCase("-s")]
        [TestCase("/v")]
        [TestCase("/s")]
        public void GivenArgumentsAreValid_ThenExceptionIsNotThrown(string firstArgument)
        {
            //Arrange
            string[] args = { firstArgument, "C:/test.txt" };

            //Act & Assert
            Assert.DoesNotThrow(() => _validator.ValidateConsoleArguments(args));
        }

        [Test]
        public void GivenWePassMoreThenTwoArgument_FirstAndSecondAreValid_ThenExceptionIsNotThrown()
        {
            //Arrange
            string[] args = { "-v", "C:/test.txt", "ThirdArgument" };

            //Act & Assert
            Assert.DoesNotThrow(() => _validator.ValidateConsoleArguments(args));
        }
    }
}
