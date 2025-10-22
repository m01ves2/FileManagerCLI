using FileManagerCLI.App.Interfaces;
using FileManagerCLI.Core.Infrastructure;
using System.Collections.Generic;

namespace FileManagerCLI.Tests.TestUtils
{
    /// <summary>
    /// Fake console UI for testing Coordinator and CommandHandler logic
    /// without any real user input/output.
    /// </summary>
    public class FakeUI : IUI
    {
        private readonly Queue<string> _inputs = new();
        public List<string> Outputs { get; } = new();

        public FakeUI(IEnumerable<string> inputs)
        {
            foreach (var input in inputs)
                _inputs.Enqueue(input);
        }

        public string ReadInput(string prompt)
        {
            // Simulate CLI prompt + reading from queue
            Outputs.Add(prompt);
            return _inputs.Count > 0 ? _inputs.Dequeue() : string.Empty;
        }

        public void WriteOutput(CommandResult commandResult)
        {
            Outputs.Add($"[{commandResult.Status}] {commandResult.Message}");
        }
    }
}