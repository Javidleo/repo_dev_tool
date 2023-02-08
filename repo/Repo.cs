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
        public static AppConfig config = null;
        public static List<Command> commands = null;
        public void Init(string[] args)
        {
            SetCommandAllies();

            Initializer.SetupCommands();

            string command = GetCommand(args);
            string[] switches = GetSwitches(args);
        }

        

        private void SetCommandAllies()
        {
            config = new AppConfig();

            config.CommandAllies.Inject("repository", "repo", "rep");

            config.CommandAllies.Inject("mapping", "map");

            config.CommandAllies.Inject("command", "com");

            config.CommandAllies.Inject("query", "q");
        }

        public string GetCommand(string[] args)
        {
            if (args is null || args.Length == 0) return "";
            return args[0].Trim().ToLower();
        }

        public string[] GetSwitches(string[] args)
        {
            if (args is null || args.Length == 0) return new string[] { };

            List<string> switchList = new();

            for(int i = 1; i < args.Length; i++) // start from 1 because the first element is the command it self;
            {
                if (args[i].StartsWith("--"))
                {
                    switchList.Add(args[i]);
                }
                else if (args[i].StartsWith("-"))
                {
                    args[i] = args[i].ToBaseSwitch();
                    switchList.Add(args[i]);
                }
            }
            return switchList.ToArray();
        }

        public void InitilizeForTest()
        {
            throw new NotImplementedException();
        }
    }
}
