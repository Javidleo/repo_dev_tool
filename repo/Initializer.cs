using repo.Exceptions;
using repo.Models;
using repo.Tools;
using System.Text.RegularExpressions;

namespace repo
{
    public class Initializer
    {
        private List<Command> commands = new List<Command>();

        public RequestType Startup(string[] args)
        {
            if (HasSpecialChar(args))
                throw new InvalidInputException("input should not contains special characters");

            var requestType = GetRequestType(args);

            SetCommandAllies();
            SetupCommands();
            return requestType;
        }

        private  RequestType GetRequestType(string[] args)
        {
            if (args[1].StartsWith("-")) 
                return RequestType.Normal;

            else
                return RequestType.Shortcut;
        }

        private bool HasSpecialChar(string[] args)
        {
            if (args is null || args.Length == 0)
                throw new ArgumentNullException("invalid input");

            var arguments = string.Join(" ", args);

            if (Regex.IsMatch(arguments, @"^[a-zA-Z0-9][\s \b \t /\-_.]*$"))
                return true;

            return false;
        }


        public void SetCommandAllies()
        {
            Repo.config = new AppConfig();

            Repo.config.CommandAllies.Inject("repository", "repo", "rep", "r","repository");

            Repo.config.CommandAllies.Inject("mapping", "map", "m","mapping");

            Repo.config.CommandAllies.Inject("command", "com", "c","command");

            Repo.config.CommandAllies.Inject("query", "q","query");
        }

        public void SetupCommands()
        {
            // ---------------------------------  Repository ----------------------------------- //
            commands.Add(new Command("repository", "create an c# file with repository template",
                new List<Switch>
                {
                    new Switch(title : "--name", symbol : "-n", info : "set a name / !!attention!! => dont add Repository in end of your name"),
                    new Switch(title : "--folder", symbol : "-f", info : "in some special situations, if you need to create your file in a specific folder from ,defined root address use this switch to define the path"),
                }));

            // -------------------------------- Mapping ------------------------------------- //
            commands.Add(new Command("mapping", "create an c# file with mapping template related to EntityFramework Core",
                 new List<Switch>
                 {
                    new Switch(title : "--name", symbol : "-n", info : "set a name / !!attention!! => dont add mapping to end of name"),
                    new Switch(title : "--database", symbol : "-d", info : "get all tables from your database and create a mapping class for them"),
                 }));

            // ------------------------------- Command ------------------------------------- // 
            commands.Add(new Command("command", "create a command class for CQRS pattern.",
                new List<Switch>
                {
                    new Switch(title : "--name", symbol : "-n", info : "set a name / !! attention!! => dont add Command to end of name"),
                }
                ));

            // ------------------------------ Query --------------------------------------- //
            commands.Add(new Command("query", "create a query class for CQRS pattern",
                new List<Switch>
                {
                    new Switch(title : "--name", symbol : "-n", info : "set a name / !!attention!! => dont add Query to end of name"),
                }
                ));

            // set to repo commands
            Repo.commands = commands;
        }

    }
}
