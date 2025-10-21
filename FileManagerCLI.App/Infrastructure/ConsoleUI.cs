using FileManagerCLI.App.Interfaces;
using FileManagerCLI.Core.Infrastructure;
using System;
using System.Text;

namespace FileManagerCLI.App.Infrastructure
{
    //вывод текста, ошибок, меню - создаёт команды из текста (связывает App и Core)
    internal class ConsoleUI : IUI
    {
        public void PrintResult(CommandResult commandResult)
        {
            Console.ForegroundColor = commandResult.Status == CommandStatus.Success? ConsoleColor.Yellow : ConsoleColor.Red;
            Console.WriteLine(commandResult.Message);
            Console.ResetColor();
        }

        public string ReadInput(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(prompt);
            Console.ResetColor();

            string input = (Console.ReadLine() ?? "").Trim().ToLower();
            return input;
        }
    }

}
