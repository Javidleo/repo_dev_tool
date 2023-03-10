using repo.Exceptions;
using repo.Handlers;
using repo.Models;
using repo.Tools;

namespace repo
{
    public class Repo
    {
        public static AppConfig config = new();
        public static List<Command> commands = new();
        public static readonly List<string> validArgumentSwitches = new() { "--folder", "--path", "--name" };
        private readonly Initializer _initializer = new Initializer();
        private IHandler _handler;


        public void Init(string[] args)
        {
            var requestType = _initializer.Startup(args);

            string command = GetCommand(args);
            if (!VerifyCommand(command))
                throw new InvalidCommandException($"Command {command} is not recognized in Applciation");

            switch (requestType)
            {
                case RequestType.Normal:
                    NormalRequestHandler(command, args);
                    break;

                case RequestType.Shortcut:
                    ShortcutRequestHandler(command, args);
                    break;
            }
        }

        private void ShortcutRequestHandler(string command, string[] args)
        {
            args = args.GetArguments();
            command = command.ToBaseCommand();

            switch (command)
            {
                case ("repository"):
                    _handler = new RepositoryHandler();
                    _handler.ShortCut(command, args);
                    break;

                case ("mapping"):
                    _handler = new MappingHandler();
                    _handler.ShortCut(command, args);
                    break;

                case ("command"):
                    _handler = new CommandHandler();
                    _handler.ShortCut(command, args);
                    break;

                case ("query"):
                    _handler = new QueryHandler();
                    _handler.ShortCut(command, args);
                    break;

                default: throw new InvalidCommandException("invalid command name");
            }
        }

        private void NormalRequestHandler(string command, string[] args)
        {
            var switchList = GetSwitches(args);
            command = command.ToBaseCommand();

            var (verified, badSwitch) = VerifyCommandSwitches(command, switchList); 
            if (!verified)
                throw new InvalidSwitchException($"the command : {command} does'nt have any implimentation for {badSwitch}");

            switch (command)
            {
                case ("repository"):
                    _handler = new RepositoryHandler();
                    _handler.Handle(command, switchList.argumentSwitches, switchList.switches);
                    break;

                case ("mapping"):
                    _handler = new MappingHandler();
                    _handler.Handle(command, switchList.argumentSwitches, switchList.switches);
                    break;

                case ("command"):
                    _handler = new CommandHandler();
                    _handler.Handle(command, switchList.argumentSwitches, switchList.switches);
                    break;

                case ("query"):
                    _handler = new QueryHandler();
                    _handler.Handle(command, switchList.argumentSwitches, switchList.switches);
                    break;

                default: throw new InvalidCommandException("invalid command name");
            }
        }

        private (bool verified, string badSwitch) VerifyCommandSwitches(string commandName, (Dictionary<string, string> argumentSwitches, string[] switches) switches)
        {
            var commandFullName = config.CommandAllies.FirstOrDefault(i => i.Key == commandName).Value;

            var command = commands.FirstOrDefault(i => i.title == commandFullName);
            if (switches.argumentSwitches != null)
            {
                foreach (var @switch in switches.argumentSwitches)
                {
                    if (!command.switches.Any(i => i.title == @switch.Key))
                        return (false, @switch.Key);
                }
            }
            if (switches.switches != null)
            {
                foreach (var @switch in switches.switches)
                {
                    if (!command.switches.Any(i => i.title == @switch))
                        return (false, @switch);
                }
            }
            return (verified: true, badSwitch: "");

        }

        public string GetCommand(string[] args)
        {
            if (args is null || args.Length == 0) return "";

            string command = args[0].Trim().ToLower();
            return command;
        }

        public (Dictionary<string, string> argumentSwitches, string[] switches) GetSwitches(string[] args)
        {
            if (args is null || args.Length == 0)
                throw new ArgumentNullException("empty argument");

            List<string> switchList = new();
            Dictionary<string, string> argumentSwitches = new();
            for (int i = 1; i < args.Length; i++) // start from 1 because the first element is the command itself;
            {
                if (args[i].StartsWith("--"))
                {
                    argumentSwitches.AddArgumentSwitches(args[i], args[i + 1]);
                    switchList.Add(args[i]);
                }
                else if (args[i].StartsWith("-"))
                {
                    args[i] = args[i].ToBaseSwitch(args[0]);
                    var isArgumentSwitch = argumentSwitches.AddArgumentSwitches(args[i], args[i + 1]);
                    if (!isArgumentSwitch)
                    {
                        switchList.Add(args[i]);
                    }
                }
            }
            return (argumentSwitches, switchList.ToArray());
        }

        public bool VerifyCommand(string inputCommand)
        {
            return Repo.config.CommandAllies.ContainsKey(inputCommand);
        }
    }
}
