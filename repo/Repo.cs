using repo.Exceptions;
using repo.Models;
using repo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace repo
{
    public class Repo
    {
        public static AppConfig config = new();
        public static List<Command> commands = new();
        public static readonly List<string> validArgumentSwitches = new() { "--folder", "--path", "--name" };
        private readonly CommandHandler _commandHandler = new();
        private readonly Initializer _initializer = new Initializer();
        public void Init(string[] args)
        {
             // setup commands and command allies

            string command = GetCommand(args);
            if (!VerifyCommand(command))
                throw new InvalidCommandException($"Command {command} is not recognized in Applciation");

            var switches = GetSwitches(args);

            var checkCommandSwitch = VerifyCommandSwitches(command, switches);
            if (!checkCommandSwitch.verified)
                throw new InvalidSwitchException($"the command : {command} does'nt have any implimentation for {checkCommandSwitch.badSwitch}");

            ProccessCommand(command, switches.argumentSwitches,switches.switches);
        }

        private void ProccessCommand(string command, Dictionary<string, string> argumentSwitches, string[] switches)
        {
            switch (command)
            {
                case ("repository"): _commandHandler.Repository(argumentSwitches, switches); break;

                case ("mapping"): _commandHandler.Mapping(argumentSwitches, switches); break;

                case ("command"): _commandHandler.Command(argumentSwitches, switches); break;

                case ("query"): _commandHandler.Query(argumentSwitches, switches); break;

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
            return args[0].Trim().ToLower();
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
                    argumentSwitches.AddArgumentSwitches(args[i], args[i++]);
                    switchList.Add(args[i]);
                }
                else if (args[i].StartsWith("-"))
                {
                    args[i] = args[i].ToBaseSwitch();
                    argumentSwitches.AddArgumentSwitches(args[i], args[i++]);
                    switchList.Add(args[i]);
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
