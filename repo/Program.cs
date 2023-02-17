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
    args = new string[] { "command", "CreateUser", "int", "id", "string", "name", "string", "family", "string", "pass" };
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

