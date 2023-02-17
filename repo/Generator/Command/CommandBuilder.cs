using repo.Generator.Common;

namespace repo.Generator.Command;

public class CommandBuilder
{
    private ItemTemplate _template;
    private string newLine = Environment.NewLine;
    private Setup _setup = Setup.Init();

    

    public CommandBuilder Once(string domainName,List<ItemInput> inputs)
    {

        _template = new ItemTemplate(domainName,inputs);
        return this;
    }

    public void Build()
    {
        var files = WriteFile();
        File.WriteAllLines(_setup.CommandSetup.path + $"\\{_template.DomainName}Command.cs", files.command);
        File.WriteAllLines(_setup.CommandSetup.path + $"\\{_template.DomainName}CommandHandler.cs", files.commandHandler);
    }

    public (string[] command, string[] commandHandler) WriteFile()
    {
        List<string> fileList = new();

        var command = WriteCommand();
        var commandHandler = WriteCommandHanlder();

        return (command, commandHandler);
    }

    private string[] WriteCommandHanlder()
    {
        List<string> handlerList = new List<string>();
        string input = "";

        handlerList.AddRange(new string[]
        {
            "using System;",
            "using System.Collections.Generic;",
            "using System.Linq;",
            "using System.Text;",
            "using System.Threading.Tasks;",
            "using MediatR",
            newLine,
            $"namespace {_setup.CommandSetup.commandNameSpace};",
            newLine,
            $"public class {_template.DomainName}CommandHandler : IRequestHandler<{_template.DomainName}Command>",
            "{",
            $"     public {_template.DomainName}CommandHandler()",
            "     {",
            "     }",
            newLine,
            $"     public async Task {_template.DomainName}CommandHandler({_template.DomainName}Command command)",
            "     {",
            "     }",
            "}"
        });
        return handlerList.ToArray();
    }

    private string[] WriteCommand()
    {
        List<string> commandList = new List<string>();
        string input = string.Empty;
        if (_template.Inputs is not null)
        {
            int i = 0;
            foreach (var item in _template.Inputs)
            {
                if(i is 0)
                {
                    input += $"{item.type} {item.name}";
                    i += 1;
                }
                else
                {
                    input += $", {item.type} {item.name}";

                }

            }
        }

        commandList.AddRange(new string[]
        {
            "using System;",
            "using System.Collections.Generic;",
            "using System.Linq;",
            "using System.Text;",
            $"using System.Threading.Tasks;{newLine}",
            $"namespace {_setup.CommandSetup.commandNameSpace};{newLine}",
            $"public record {_template.DomainName}Command({input});"
        });
        return commandList.ToArray();
    }
}
