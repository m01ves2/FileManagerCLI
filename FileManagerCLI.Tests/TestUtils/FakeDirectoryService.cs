using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Services;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;

namespace FileManagerCLI.Tests.TestUtils
{
    public class FakeDirectoryService : IDirectoryService
    {
        private readonly HashSet<string> _directories = new(StringComparer.OrdinalIgnoreCase);

        public void CopyDirectory(string source, string destination)
        {
            if(_directories.Contains(source))
                _directories.Add(destination);
        }

        public void CreateDirectory(string path) => _directories.Add(path);

        public void DeleteDirectory(string path)
        {
            if (!_directories.Contains(path))
                throw new DirectoryNotFoundException($"Directory '{path}' not found.");

            _directories.Remove(path);
        }

        public bool Exists(string path) => _directories.Contains(path);

        public bool IsDirectory(string source) => _directories.Contains(source);

        public string[] ListDirectory(string path)
        {
            return _directories.ToArray();
        }

        public void MoveDirectory(string source, string destination)
        {
            if (!_directories.Contains(source))
                throw new DirectoryNotFoundException($"Directory '{source}' not found.");

            _directories.Remove(source);
            _directories.Add(destination);
        }
    }
}