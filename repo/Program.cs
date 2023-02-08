// See https://aka.ms/new-console-template for more information
using repo;
using repo.Exceptions;
using System.Data;

var repo = new Repo();
try
{
    repo.Init(args);

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

        default: ExceptionWriter(typeof(Exception), "internal system error, please report this error to author");
            break;
    }
}

void ExceptionWriter(Type excpetionType ,string message, string help = "use repo --help / -h to see all commands")
{
    var previousColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine($"{excpetionType.Name} is happend: {Environment.NewLine} Message : {message} {Environment.NewLine} Help : {help}");
    Console.ForegroundColor = previousColor;
}

