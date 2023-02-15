using repo.Exceptions;

namespace repo.Tools
{
    public static class Helper
    {
        public static void CheckHelpRequest(string commandName, string[] args)
        {
            bool helpExist = args.Any(i => i == "--help" || i == "-h");
                //Array.IndexOf(args, "-h") != -1 || Array.IndexOf(args, "--help") != -1;
            if (helpExist)
            {
                var command = Repo.commands.FirstOrDefault(i => i.title == commandName);

                MessageHandler.PrintHelp(command);
            }

        }
        public static void CheckHelpRequest(string commandName, Dictionary<string, string> argumentSwitches)
        {
            bool helpExist = argumentSwitches.Keys.Any(i => i == "-help" || i == "-h");
            if (helpExist)
            {
                var command = Repo.commands.FirstOrDefault(i => i.title == commandName);

                MessageHandler.PrintHelp(command);
            }
        }

        public static string[] TakeFromArray(this string[] input, int fromIndex, int toIndex)
        {
            string[] array = new string[toIndex - fromIndex];

            int j = 0;
            for (int i = fromIndex; i < toIndex; i++)
            {
                array[j] = input[i];
                j++;
            }
            return array;
        }
        public static bool AddArgumentSwitches(this Dictionary<string, string> argumentSwitchList, string @switch, string value)
        {
            var argumentSwitch = Repo.validArgumentSwitches.FirstOrDefault(i => i == @switch);

            if (argumentSwitch is not null)
            {
                argumentSwitchList.Add(argumentSwitch, value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// this helper method remove the command item from the args array for shortcut process 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string[] GetArguments(this string[] args)
        {
            string[] result = new string[args.Length - 1];
            for (int i = 1; i < args.Length; i++)
            {
                result[i - 1] = args[i];
            }
            return result;
        }

        public static string ToBaseCommand(this string input)
        {
            var command = Repo.config.CommandAllies.FirstOrDefault(i => i.Key == input);

            return command.Value;
        }

        public static string ToBaseSwitch(this string switchSymbol, string commandFullName)
        {
            if (string.IsNullOrEmpty(switchSymbol))
                return null;

            var command = Repo.commands.FirstOrDefault(i => i.title == commandFullName);
            if (command is null)
                throw new InvalidCommandException($"{commandFullName} is not recognized as a valid command");

            var @switch = command.switches.FirstOrDefault(i => i.symbol == switchSymbol);
            if (@switch is null)
                throw new InvalidSwitchException($"{switchSymbol} is not recognized as a valid switch for {commandFullName}");

            return @switch.title;
        }
    }
}
