using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.Handlers
{
    public class CommandHandler : IHandler
    {
        public void Handle(string command, Dictionary<string, string> argumentSwitches, string[] switches)
        {
            throw new NotImplementedException();
        }

        public void ShortCut(string command, string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
