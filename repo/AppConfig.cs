namespace repo
{
    public class AppConfig
    {
        public AppConfig()
        {
            CommandAllies = new();
        }
        public Dictionary<string,string> CommandAllies { get; set; }
    }
}