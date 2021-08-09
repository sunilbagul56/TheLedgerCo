using FluentAssertions;
using TheLedgerCompany.Contract;
using Xunit;

namespace TheLedgerCompany.UnitTests
{
    public class FileProcessorTest
    {
        public IFileProcessor fileProcessor;
        public const string fileName = @"Mock/TheLedgerCo-Sample-2.txt";

        public FileProcessorTest()
        {
            fileProcessor = new FileProcessor();
        }

        [Fact]
        public void FileProcessor_Success()
        {
            //Arrange

            //Act
            string[] getAllCommand = fileProcessor.ProcessInputFile(fileName);

            //Assert
            getAllCommand.Should().NotBeNull();
            getAllCommand.Should().HaveCountGreaterThan(0);
        }
    }
}
