using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.Models
{
    public record Command(string title, string info, List<Switch> switches);
}
