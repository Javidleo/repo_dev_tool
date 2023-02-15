using Newtonsoft.Json;

namespace repo
{
    public class Setup
    {
        public GlobalSetup GlobalSetup { get; set; }
        public RepositorySetup RepositorySetup { get; set; }
        public MappingSetup MappingSetup { get; set; }
        public CommandSetup CommandSetup { get; set; }
        public QuerySetup QuerySetup { get; set; }

        public Setup()
        {


        }
        public static Setup Init()
        {
            var setupJson = File.ReadAllText(AppContext.BaseDirectory + @"\setup.json");
            var setup = JsonConvert.DeserializeObject<Setup>(setupJson);

            return setup;
        }
    }

    public record GlobalSetup(string serviceNameSpace, string dbContextNameSpace, string domainModelNameSpace, string path);

    public record RepositorySetup(bool useGeneric, string dataAccessNameSpace, string serviceNameSpace, string path);

    public record MappingSetup(string mappingNameSpace, string path);

    public record CommandSetup(string commandNameSpace, string path);

    public record QuerySetup(string queryNameSpace, string path);
}
