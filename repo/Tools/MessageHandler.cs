using repo.Models;

namespace repo.Tools
{
    public class MessageHandler
    {
        public static void PrintSuccessMessage(string message, ConsoleColor color = ConsoleColor.Blue)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        public static void PrintHelp(Command command)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"{command.title} command description");

            foreach (var @switch in command.switches)
                Console.WriteLine($"{@switch.title}   {@switch.symbol}    {@switch.info}");
        }
    }
}
