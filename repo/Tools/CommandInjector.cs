namespace repo.Tools
{
    public static class CommandInjector
    {
        public static void Inject(this Dictionary<string, string> commandAllies, string command, string ally)
        {
            commandAllies.Add(ally, command);
        }
        public static void Inject(this Dictionary<string, string> commandAllies, string command, string ally, string ally2)
        {
            commandAllies.Add(ally, command);
            commandAllies.Add(ally2, command);
        }
        public static void Inject(this Dictionary<string, string> commandAllies, string command, string ally, string ally2, string ally3)
        {
            commandAllies.Add(ally, command);
            commandAllies.Add(ally2, command);
            commandAllies.Add(ally3, command);
        }
        public static void Inject(this Dictionary<string, string> commandAllies, string command, string ally, string ally2, string ally3, string ally4)
        {
            commandAllies.Add(ally, command);
            commandAllies.Add(ally2, command);
            commandAllies.Add(ally3, command);
            commandAllies.Add(ally4, command);
        }

        public static void Inject(this Dictionary<string, string> commandAllies, string command, string ally, string ally2, string ally3, string ally4, string ally5)
        {
            commandAllies.Add(ally, command);
            commandAllies.Add(ally2, command);
            commandAllies.Add(ally3, command);
            commandAllies.Add(ally4, command);
            commandAllies.Add(ally5, command);
        }
    }
}