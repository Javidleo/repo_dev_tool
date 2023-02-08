using repo.Models;
using repo.Tools;
using System.Runtime.CompilerServices;

namespace repo
{
    public class Initializer
    {
        public string[] Startup(string[] args)
        {
            var validArgs = CheckInput(args);
            SetCommandAllies();
            SetupCommands();
            return validArgs;
        }

        private string[] CheckInput(string[] args)
        {

            return new string[] { };
        }

        private static List<Command> commands = new List<Command>();
        
        public void SetCommandAllies()
        {
            Repo.config = new AppConfig();

            Repo.config.CommandAllies.Inject("repository", "repo", "rep", "r");

            Repo.config.CommandAllies.Inject("mapping", "map", "m");

            Repo.config.CommandAllies.Inject("command", "com", "c");

            Repo.config.CommandAllies.Inject("query", "q");
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
