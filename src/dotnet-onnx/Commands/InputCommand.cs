using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Onnx;

public abstract class InputCommand : Command
{
    public readonly IConsole _console;
    public Action<string> LogInput;

    public InputCommand(IConsole console)
    {
        _console = console;
        LogInput = t => _console.WriteLine(t);
    }

    [Argument(0, "input", Description = "Input file path")]
    [Required]
    public string Input { get; }

    public override Task Run()
    {
        var model = ModelProto.Parser.ParseFromFile(Input);

        LogInput?.Invoke($"Parsed input file '{Input}' of size {model.CalculateSize()}");

        Run(model);

        return Task.CompletedTask;
    }

    public abstract void Run(ModelProto model);
}
