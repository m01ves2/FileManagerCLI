using FileManagerCLI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Tests.Services
{
    public class DirectoryServiceTests : IDisposable
    {
        private readonly DirectoryService _service = new();
        private readonly string _tempRoot;

        public DirectoryServiceTests()
        {
            _tempRoot = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempRoot);
        }

        [Fact]
        public void CreateDirectory_Should_Create_Folder()
        {
            // Arrange
            string path = Path.Combine(_tempRoot, "testdir");

            // Act
            _service.CreateDirectory(path);

            // Assert
            Assert.True(Directory.Exists(path));
        }

        [Fact]
        public void DeleteDirectory_Should_Remove_Folder()
        {
            // Arrange
            string path = Path.Combine(_tempRoot, "todelete");
            Directory.CreateDirectory(path);

            // Act
            _service.DeleteDirectory(path);

            // Assert
            Assert.False(Directory.Exists(path));
        }

        public void Dispose()
        {
            if (Directory.Exists(_tempRoot))
                Directory.Delete(_tempRoot, true);
        }
    }
}
