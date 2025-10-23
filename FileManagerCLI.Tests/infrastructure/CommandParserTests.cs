using FileManagerCLI.App.Infrastructure;

namespace FileManagerCLI.Tests.infrastructure
{
    public class CommandParserTests
    {
        private readonly CommandParser _parser = new();
        [Fact]
        public void CommandParserTests_Should_Return_Splitted_String()
        {
            string input = "cp -a file1 file2";
            (string commandName, string[] args) = _parser.Parse(input);
            Assert.Equal("cp", commandName);
            Assert.Equal(["-a", "file1", "file2"], args);
        }

        [Fact]
        public void Parse_Should_Handle_Empty_Input()
        {
            // Arrange
            string input = "   ";

            // Act
            var (command, args) = _parser.Parse(input);

            // Assert
            Assert.Equal("", command);
            Assert.Empty(args);
        }
    }
}
