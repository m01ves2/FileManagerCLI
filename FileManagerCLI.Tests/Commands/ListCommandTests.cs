using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Infrastructure;
using FileManagerCLI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Tests.Commands
{
    public class ListCommandTests
    {       
        private readonly string _tempDir;

        public ListCommandTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
        }

        [Fact]
        public void ListCommand_Should_Return_List_Of_Files()
        {
            // Arrange
            string sourceFile = Path.Combine(_tempDir, "source.txt");
            string sourceFile2 = Path.Combine(_tempDir, "source2.txt");
            string source = _tempDir;
            File.WriteAllText(sourceFile, "test data");
            File.WriteAllText(sourceFile2, "test data2");

            var cmd = new ListCommand(new FileService(), new DirectoryService());
            var result = cmd.Execute(new CommandContext(), new[] { source });

            Assert.Equal(CommandStatus.Success, result.Status);
        }

        [Fact]
        public void ListCommand_Should_Return_List_Of_File_Attributes()
        {
            // Arrange
            string sourceFile = Path.Combine(_tempDir, "source.txt");
            string source = _tempDir;
            File.WriteAllText(sourceFile, "test data");

            var cmd = new ListCommand(new FileService(), new DirectoryService());
            var result = cmd.Execute(new CommandContext(), new[] { sourceFile });

            Assert.Equal(CommandStatus.Success, result.Status);
        }

        public void Dispose()
        {
            if (Directory.Exists(_tempDir))
                Directory.Delete(_tempDir, true);
        }
    }
}
