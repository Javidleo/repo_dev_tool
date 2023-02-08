using repo.Models;
using System.Runtime.CompilerServices;

namespace repo
{
    public class Initializer
    {
        private static List<Command> commands = new List<Command>();

        public static void SetupCommands()
        {

            commands.Add(new Command(
                title: "repository",
                info: "create an c# file with repository template",
                switches: new List<Switch>
                {
                    new Switch("--","","create and instance of c# repository file"),
                    new Switch("--","","set the file parent Domain model to know where to create the file"),
                }
                ));

            commands.Add(new Command("repository", "create an c# file with repository template",
                 new List<Switch>
                 {
                    new Switch("--","","create and instance of c# repository file"),
                    new Switch("--","","set the file parent Domain model to know where to create the file"),
                 }));

            commands.Add(new Command("repository", "create an c# file with repository template",
                new List<Switch>
                {
                    new Switch("--","","create and instance of c# repository file"),
                    new Switch("--","","set the file parent Domain model to know where to create the file"),
                }
                ));

            commands.Add(new Command("repository", "create an c# file with repository template",
                new List<Switch>
                {
                    new Switch("--","","create and instance of c# repository file"),
                    new Switch("--","","set the file parent Domain model to know where to create the file"),
                }
                ));

            commands.Add(new Command("repository", "create an c# file with repository template",
                new List<Switch>
                {
                    new Switch("--","","create and instance of c# repository file"),
                    new Switch("--","","set the file parent Domain model to know where to create the file"),
                }
                ));

            // set to repo commands
            Repo.commands = commands;
        }

        [Flags]
        public enum colors
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            White = 3
        }


    }
}
