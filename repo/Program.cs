// See https://aka.ms/new-console-template for more information
using repo;
using repo.Exceptions;
using repo.Generator.Common;
using repo.Generator.Mapping;

//string[] s = { "command", "--name" };
//if (s[1].StartsWith('-') || s[0].StartsWith('-')) throw new Exception("eee");
var repo = new Repo();

try
{
<<<<<<< HEAD
    ////MappingBuilder generator = new MappingBuilder();
    ////generator.Once("Admin").BuildOne();
    //if (!File.Exists(Environment.CurrentDirectory + @"\setup.json"))
    //{

    //}
    Setup.GenerateVizardSetup();
=======
    args = new string[] { "command", "CreateUser", "int", "id", "string", "name", "string", "family", "string", "pass" };
>>>>>>> 24a980fcae54cd5f4c94c5512d09a64b91cc623e
    repo.Init(args);
    //repo.Init(args);

}
catch (Exception ex)
{
    HandleException(ex);
    Console.ReadKey();
}

void HandleException(Exception ex)
{
    switch (ex)
    {
        case (InvalidCommandException):
            ExceptionWriter(typeof(InvalidCommandException), ex.Message);
            break;

        case (InvalidSwitchException):
            ExceptionWriter(typeof(InvalidCommandException), ex.Message);
            break;

        default:
            ExceptionWriter(typeof(Exception), ex.Message);
            break;
    }
}

void ExceptionWriter(Type excpetionType, string message, string help = "use repo --help / -h to see all commands")
{
    var previousColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine($"{excpetionType.Name} is happend: {Environment.NewLine} Message : {message} {Environment.NewLine} Help : {help}");
    Console.ForegroundColor = previousColor;
}

