using FileManagerCLI.App.Interfaces;
using FileManagerCLI.Core.Infrastructure;
using System.Text;

namespace FileManagerCLI.App.Infrastructure
{
    //вывод текста, ошибок, меню - создаёт команды из текста (связывает App и Core)
    internal class ConsoleUI : IUI
    {
        private readonly ICommandHandler _commandHandler;

        public ConsoleUI(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        internal void Start()
        {
            PrintMenu();
            while (true) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(_commandHandler.GetCLIPrompt());
                Console.ResetColor();

                string input = ReadInput();

                if (string.IsNullOrEmpty(input)) {
                    continue;
                }
                else if (input.Equals("exit")) {
                    break;
                }
                else if (input.Equals("help")) {
                    PrintMenu();
                    continue;
                }

                CommandResult commandResult = _commandHandler.Execute(input);
                PrintResult(commandResult);
            }
        }

        private void PrintMenu()
        {
            StringBuilder sb = new StringBuilder(); //TODO get command list from App-layer/Register->Core-Layer/Commands
            sb.AppendLine("FileManagerCLI v0.1");
            sb.AppendLine("Available commands:");
            sb.AppendLine("ls       - List directory contents");
            sb.AppendLine("cd       - Change directory");
            sb.AppendLine("cp       - Copy file or directory");
            sb.AppendLine("rm       - Remove file or directory");
            sb.AppendLine("help     - Show this help message");
            sb.AppendLine("exit     - Exit the program");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
         
        }

        public void PrintResult(CommandResult commandResult)
        {
            Console.WriteLine(commandResult.Message);
        }

        public string ReadInput()
        {
            string input = (Console.ReadLine() ?? "").Trim().ToLower();
            return input;
        }
    }

}
