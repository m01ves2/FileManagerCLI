using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Services;
using System.Collections.Generic;
using System.IO;

namespace FileManagerCLI.Tests.TestUtils
{
    /// <summary>
    /// In-memory implementation of IFileService for fast and isolated testing.
    /// Simulates file operations without touching the real filesystem.
    /// </summary>
    public class FakeFileService : IFileService
    {
        private readonly Dictionary<string, string> _files = new(StringComparer.OrdinalIgnoreCase);

        public bool Exists(string path) => _files.ContainsKey(path);

        public void CopyFile(string source, string destination)
        {
            if (!_files.ContainsKey(source))
                throw new FileNotFoundException($"File '{source}' not found.");

            _files[destination] = _files[source];
        }

        public void MoveFile(string source, string destination)
        {
            if (!_files.ContainsKey(source))
                throw new FileNotFoundException($"File '{source}' not found.");

            _files[destination] = _files[source];
            _files.Remove(source);
        }

        public void DeleteFile(string path)
        {
            if (!_files.ContainsKey(path))
                throw new FileNotFoundException($"File '{path}' not found.");

            _files.Remove(path);
        }

        public void CreateFile(string path)
        {
            string content = "Hello, world!";
            _files[path] = content;
        }
        public string Read(string path)
        {
            if (!_files.ContainsKey(path))
                throw new FileNotFoundException($"File '{path}' not found.");
            return _files[path];
        }

        public FileInfo GetFileInfo(string path)
        {
            return new FileInfo(path) { CreationTime = DateTime.Now };
        }

        public bool IsFile(string source) => _files.ContainsKey(source);
    }
}