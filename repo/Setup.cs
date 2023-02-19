using Newtonsoft.Json;
using static System.Console;
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
            var setupJson = File.ReadAllText(Environment.CurrentDirectory + @"\setup.json");
            var setup = JsonConvert.DeserializeObject<Setup>(setupJson);

            return setup;
        }

        public static void Build()
        {
            WriteLine("Setup File doesnt exist in current directory");
            WriteLine("We will build one for you.");
            WriteLine("send 1 for manual mode to generate an empty setup file for you");
            WriteLine("send 2 for help you to create your own setup file");
            string mode = ReadLine();

            if (mode is "1")
            {
                GenerateEmptySetup();
            }
            if (mode is "2")
            {
                GenerateVizardSetup();
            }
            else
            {
                Console.WriteLine("invalid mode");
                Exit();
            }
        }
        private static void WriteTitle(string title)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;

            WriteLine($"----------------------------{title}----------------------------");

            Console.ForegroundColor = previousColor;
        }
        public static void GenerateVizardSetup()
        {
            
            /// ---------------------------------- Global Setup
            WriteLine("");
            WriteTitle("GlobalSetup");
            Write("Enter WriteDbContext NameSpace : "); string writeDbContextNameSpace = ReadLine();
            Write("Enter ReadDbContext NameSpace : "); string readDbContextNameSpace = ReadLine();
            Write("Enter Domain Models NameSpace : "); string domainsNameSpace = ReadLine();
            WriteTitle("End Setup");

            ///----------------------------------- Repository Setup
            WriteLine("");
            WriteTitle("RepositorySetup");
            Write("Do you preffer to use Generic Repository? y/n"); bool useGeneric = ReadLine() == "y" ? true : false;
            Write("Enter Repository Implementation NameSpace : "); string RepoImplementationNameSpace = ReadLine();
            Write("Enter Repository Contract NameSpace : "); string repoInterfaceNameSpace = ReadLine();
            Write("a valid path to store : "); string repositoryPath = ReadLine();

            ///---------------------------------- Mapping Setup
            WriteLine("");
            WriteTitle("MappingSetup");
            Write("Enter Mapping NameSpace : ");string mappingNameSpace = ReadLine();
            Write("a valid path to store : ");string mappingPath = ReadLine();

            ///---------------------------------- Command Setup
            WriteLine("");
            WriteTitle("CommandSetup");
            Write("Enter Command NameSpace : ");string commandNameSpace = ReadLine();
            Write("Enter Command Handler NameSpace : ");string commandHandlerNameSpace = ReadLine();
            Write("a valid path to store : ");string commandPath = ReadLine();

            ///---------------------------------- Query Setup
            WriteLine("");
            WriteTitle("QuerySetup");
            Write("Enter Query NameSpace : ");string queryNameSpace = ReadLine();
            Write("a valid path to store : "); string queryPath = ReadLine();

            var global = new GlobalSetup(writeDbContextNameSpace, readDbContextNameSpace, domainsNameSpace);
            var repository = new RepositorySetup(useGeneric, RepoImplementationNameSpace, repoInterfaceNameSpace, repositoryPath);
            var mapping = new MappingSetup(mappingNameSpace, mappingPath);
            var command = new CommandSetup(commandNameSpace, commandPath);
            var query = new QuerySetup(queryNameSpace, queryPath);

            var setup = new Setup()
            {
                GlobalSetup = global,
                RepositorySetup = repository,
                MappingSetup = mapping,
                CommandSetup = command,
                QuerySetup = query
            };

            var json = JsonConvert.SerializeObject(setup,Formatting.Indented);
            File.WriteAllText(Environment.CurrentDirectory + @"\setup.json",json);
        }

        public static void GenerateEmptySetup()
        {
            var setup = new Setup();
            var json = JsonConvert.SerializeObject(setup, Formatting.Indented);
            File.WriteAllText(Environment.CurrentDirectory + @"\setup.json", json);
        }

        private static void Exit()
        {
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
            Environment.Exit(1);
            return;
        }
    }

    public record GlobalSetup(string writeDbContextNameSpace,string readDbContextNameSpace,string domainModelNameSpace);

    public record RepositorySetup(bool useGeneric, string implementationNameSpace, string interfaceNameSpace, string path);

    public record MappingSetup(string mappingNameSpace, string path);

    public record CommandSetup(string commandNameSpace, string path);

    public record QuerySetup(string queryNameSpace, string path);
}
