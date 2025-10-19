using FileManagerCLI.App.Services;
using FileManagerCLI.Core.Commands;
using FileManagerCLI.Core.Interfaces;
using FileManagerCLI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerCLI.App.Infrastructure
{
    internal class CommandParser
    {
        public (string commandName, string[] args) Parse(string input)
        {
            var tokens = input.Trim().ToLower().Split(' ');
            string commandName = tokens[0];
            string[] args = tokens.Skip(1).ToArray();

            return (commandName, args);
        }
    }
}
