using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Interfaces
{
    public interface IItem
    {
        string Path { get; }
        string Name { get; }
        bool Exists();
    }
}
