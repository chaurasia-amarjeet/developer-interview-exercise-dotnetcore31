using FileData.Enum;
using FileData.Extensions;
using NUnit.Framework;

namespace UnitTestProject.FileData.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase("-v", Operation.FileVersion)]
        [TestCase("/v", Operation.FileVersion)]
        [TestCase("-s", Operation.FileSize)]
        [TestCase("/s", Operation.FileSize)]
        public void GivenValidArgument_WhenGetOperationIsCalled_ThenCorrectOperationTypeReturend(string argument, Operation expectedOperation)
        {
            //Act
            var result = argument.GetOperation();

            //Assert
            Assert.AreEqual(expectedOperation, result);
        }
    }
}
