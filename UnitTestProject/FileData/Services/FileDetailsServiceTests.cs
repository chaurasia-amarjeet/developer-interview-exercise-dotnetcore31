using FileData.Interfaces;
using FileData.Services;
using Moq;
using NUnit.Framework;
using ThirdPartyTools;

namespace UnitTestProject.FileData.Services
{
    [TestFixture]
    public class FileDetailsServiceTests
    {
        private const string FilePath = "C:/test.txt";
        private IFileDetailsService _fileDetailsService;

        [SetUp]
        public void SetUp()
        {
            _fileDetailsService = new FileDetailsService(new FileDetails());
        }

        [TearDown]
        public void TearDown()
        {
            _fileDetailsService = null;
        }

        [Test]
        public void GivenValidFilePath_WhenICallGetFileVersion_ThenFileVersionShouldBeReturned()
        {
            //Arrange
            var filePath = FilePath;

            //Act
            var result = _fileDetailsService.GetFileVersion(filePath);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GivenValidFilePath_WhenICallGetFileSize_ThenFileSizeShouldBeReturned()
        {
            //Arrange
            var filePath = FilePath;

            //Act
            var result = _fileDetailsService.GetFileSize(filePath);

            //Assert
            Assert.AreNotEqual(0, result);
        }
    }
}
