using repo.Generator.Command;
using repo.Generator.Common;
using repo.Tools;

namespace repo.Handlers
{
    public class CommandHandler : IHandler
    {
        private readonly CommandBuilder _commandBuilder;

        private Dictionary<string, string> types = new();

        private void FillTypeCheckList()
        {
            types.Add("int", "int");
            types.Add("Int", "int");
            types.Add("int32", "int");

            types.Add("uint", "uint");
            types.Add("Uint", "uint");
            types.Add("UInt", "uint");

            types.Add("object", "object");
            types.Add("Object", "object");
            types.Add("obj", "obj");

            types.Add("dynamic", "dynamic");
            types.Add("Dynamic", "dynamic");

            types.Add("long", "long");
            types.Add("int64", "long");

            types.Add("byte", "byte");
            types.Add("Byte", "Byte");

            types.Add("float", "float");
            types.Add("Float", "float");

            types.Add("double", "double");
            types.Add("Double", "double");
            types.Add("dob", "double");

            types.Add("sbyte", "sbyte");
            types.Add("Sbyte", "sbyte");

            types.Add("decimal", "decimal");
            types.Add("Decimal", "decimal");
            types.Add("decim", "decimal");

            types.Add("string", "string");
            types.Add("String", "string");
            types.Add("str", "string");

            types.Add("date", "DateTime");
            types.Add("datetime", "DateTime");
            types.Add("dateTime", "DateTime");
            types.Add("DateTime", "DateTime");
            types.Add("Date", "DateTime");

            types.Add("char", "char");
            types.Add("Char", "char");

            types.Add("bool", "bool");
            types.Add("Bool", "bool");
            types.Add("Boolean", "bool");

        }

        public CommandHandler()
        {
            _commandBuilder = new CommandBuilder();
        }

        public void Handle(string command, Dictionary<string, string> argumentSwitches, string[] switches)
        {
            throw new NotImplementedException();
        }

        public List<ItemInput> GetItems(string[] args)
        {
            var inputList = new List<ItemInput>();

            ItemInput input;
            string type = "";
            // starting from second index because the first index is the domain Name
            for(int i = 1; i < args.Length; i += 2)
            {
                type = types.FindType(args[i]);
                if (string.IsNullOrEmpty(type))
                {
                    input = new ItemInput(args[i], args[i + 1]);
                    inputList.Add(input);
                }
                input = new ItemInput(type, args[i + 1]);
                inputList.Add(input);
            }

            return inputList;
        }

        public void ShortCut(string command, string[] args)
        {

            FillTypeCheckList();
            var inputItems = GetItems(args);
            _commandBuilder.Once(domainName: args[0], inputItems).Build();

            //_commandBuilder.Once(args[0]).Build();
            
            MessageHandler.PrintSuccessMessage("command created successfully");
        }
    }
}
