using repo.Generator.Common;

namespace repo.Generator.Command
{
    public class CommandGenerator
    {
        private ItemTemplate _template;
        private string newLine = Environment.NewLine;
        private Setup _setup = Setup.Init();

        public CommandGenerator(string name, List<ItemInput> inputs)
        {
            _template = new ItemTemplate(name, inputs);
        }

        public void Build()
        {
            throw new NotImplementedException();
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
            if (_template.Inputs is not null)
            {
                foreach (var item in _template.Inputs)
                    input += $"{item.type} {item.name}, ";
            }

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
                $"  public class {_template.DomainName}CommandHandler : IRequestHandler<{_template.DomainName}Command>",
                "   {",
                ""
            });
            return handlerList.ToArray();
        }

        private string[] WriteCommand()
        {
            List<string> commandList = new List<string>();
            string input = string.Empty;
            if (_template.Inputs is not null)
            {
                foreach (var item in _template.Inputs)
                    input += $"{item.type} {item.name}, ";
            }

            commandList.AddRange(new string[]
            {
                "using System;",
                "using System.Collections.Generic;",
                "using System.Linq;",
                "using System.Text;",
                "using System.Threading.Tasks;",
                newLine,
                $"namespace {_setup.CommandSetup.commandNameSpace};",
                newLine,
                $"public record {_template.DomainName}Command({input});"
            });
            return commandList.ToArray();
        }
    }
}
