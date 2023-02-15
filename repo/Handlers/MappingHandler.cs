using repo.Generator.Mapping;
using repo.Tools;


namespace repo.Handlers
{
    public class MappingHandler : IHandler
    {
        private MappingBuilder _builder = new MappingBuilder();
        public void Handle(string commandName, Dictionary<string, string> argumentSwitches, string[] switches)
        {
            Helper.CheckHelpRequest(commandName, switches);
            Helper.CheckHelpRequest(commandName, argumentSwitches);

            string name = argumentSwitches.FirstOrDefault(i => i.Key == "--name").Value;
            string dbName = argumentSwitches.FirstOrDefault(i => i.Key == "--database").Value;
            

            if (!string.IsNullOrEmpty(name))
                BuildOne(name);

            else if (string.IsNullOrEmpty(dbName))
                BuildAllFromDatabase(dbName);

            else if (switches.Any(i => i == "--ef"))
                BuildFromDomains();
        }

        private void BuildOne(string name)
        {
            _builder.Once(name).BuildOne();
            MessageHandler.PrintSuccessMessage($"{name}Mapping.cs created successfully");
        }

        private void BuildFromDomains()
        {
            throw new NotImplementedException();
        }

        private void BuildAllFromDatabase(string dbName)
        {
            throw new NotImplementedException();
        }

        public void ShortCut(string command, string[] args)
        {

            // args.length -1 means to end of array
            // for mapping shortcut we have this order to define the whole command.
            // argsWithoutCommand items are in the following order
            // 1 : its the name of the domain we have
            // for now I dont have no more options to add.
            // so. it just working like this => repo mapping/map/m [NameofDomain]

            string domainName = args[0];
            _builder.Once(domainName).BuildOne();
            MessageHandler.PrintSuccessMessage("created successfully");
        }
    }
}
