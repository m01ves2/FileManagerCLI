using FileManagerCLI.App.Interfaces;
using FileManagerCLI.Core.Infrastructure;
using System;
using System.Text;

namespace FileManagerCLI.App.Infrastructure
{
    //вывод текста, ошибок, меню - создаёт команды из текста (связывает App и Core)
    internal class ConsoleUI : IUI
    {
        public void WriteOutput(CommandResult commandResult)
        {
            if(commandResult.Status == CommandStatus.Success)
                WriteOK(commandResult.Message);
            else if(commandResult.Status == CommandStatus.Error)
                WriteError(commandResult.Message);
        }

        public string ReadInput(string prompt)
        {
            Write(prompt);
            string input = (Console.ReadLine() ?? "").Trim();
            return input;
        }

        private void Write(string message)
        { 
            Console.ResetColor();
            Console.Write(message); 
        }
        private void WriteOK(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message); 
            Console.ResetColor();
        }
        private void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

}
