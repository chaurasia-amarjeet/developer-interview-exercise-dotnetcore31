using FileData.Interfaces;
using FileData.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTestProject.FileData.Services
{
    [TestFixture]
    public class ExecuterTests
    {
        private Mock<IFileDetailsService> _fileDetailsServiceMock;
        private Mock<IValidator> _validatorMock;
        private Mock<ILogger<Executer>> _loggerMock;

        private IExecuter _executer;

        [SetUp]
        public void SetUp()
        {
            _validatorMock = new Mock<IValidator>();
            _fileDetailsServiceMock = new Mock<IFileDetailsService>();
            _loggerMock = new Mock<ILogger<Executer>>();

            _executer = new Executer(_fileDetailsServiceMock.Object, _validatorMock.Object, _loggerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _executer = null;
            _fileDetailsServiceMock = null;
            _validatorMock = null;
        }

        [TestCase("-v")]
        [TestCase("/v")]
        public void GivenWePassFirstForVersion_ThenCorrectMethodIsCalled(string firstArg)
        {
            //Arrange
            _fileDetailsServiceMock
                .Setup(f => f.GetFileVersion(It.IsAny<string>()))
                .Returns("6.734.2472.242");

            string[] args = { firstArg, "C:/test.txt" };

            //Act
            _executer.Execute(args);

            //Assert
            _fileDetailsServiceMock.Verify(f => f.GetFileVersion(args[1]), Times.Once);
        }

        [TestCase("-s")]
        [TestCase("/s")]
        public void GivenWePassFirstForZize_ThenCorrectMethodIsCalled(string firstArg)
        {
            //Arrange
            _fileDetailsServiceMock
                .Setup(f => f.GetFileSize(It.IsAny<string>()))
                .Returns(236752);

            string[] args = { firstArg, "C:/test.txt" };

            //Act
            _executer.Execute(args);

            //Assert
            _fileDetailsServiceMock.Verify(f => f.GetFileSize(args[1]), Times.Once);
        }
    }
}
