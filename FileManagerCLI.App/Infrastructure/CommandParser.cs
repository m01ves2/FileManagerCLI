namespace FileManagerCLI.App.Infrastructure
{
    internal class CommandParser
    {
        public (string commandName, string[] args) Parse(string input)
        {
            var tokens = input.Trim().Split(' ');
            string commandName = tokens[0].ToLowerInvariant();
            string[] args = tokens.Skip(1).ToArray();

            return (commandName, args);
        }
    }
}
