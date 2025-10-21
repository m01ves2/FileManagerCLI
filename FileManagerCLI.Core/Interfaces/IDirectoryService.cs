using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Interfaces
{
    public interface IDirectoryService
    {
        string[] ListDirectory(string path);
        void CreateDirectory(string path);
        void DeleteDirectory(string path);
        void CopyDirectory(string source, string destination);
        void MoveDirectory(string source, string destination);
        bool IsDirectory(string source);
    }
}
