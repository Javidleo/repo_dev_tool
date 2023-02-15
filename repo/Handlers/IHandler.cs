namespace repo.Handlers
{
    public interface IHandler
    {
        void ShortCut(string command, string[] args);
        void Handle(string command, Dictionary<string, string> argumentSwitches, string[] switches);
    }
}
