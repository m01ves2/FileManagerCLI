using FileManagerCLI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.Core.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        CommandResult Execute(IItem item, string[] args);
    }
}
