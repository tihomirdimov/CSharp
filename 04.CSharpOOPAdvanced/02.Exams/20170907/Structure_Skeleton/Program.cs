public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new Reader();
        IWriter writer = new Writer();
        ICommandInterpreter interpreter = new CommandInterpreter();
        Engine engine = new Engine(reader, writer, interpreter);
        engine.Run();
    }
}