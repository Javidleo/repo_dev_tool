using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.Handlers
{
    public interface IHandler
    {
        void ShortCut(string command, string[] args);
        void Handle(string command, Dictionary<string, string> argumentSwitches, string[] switches);
    }
}
