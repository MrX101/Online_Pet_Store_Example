using System.Diagnostics;

namespace Online_Pet_Store_Example;

public static class Logger
{
    public static void Log(string text)
    {
        Console.WriteLine(text);
        Debug.WriteLine(text);
    }

    public static Guid LogInternalServerError( Exception e)
    {
        var guid = Guid.NewGuid();
        var msg = $"{guid} {e.ToString()}";
        Console.WriteLine(msg);
        Debug.WriteLine(msg);
        return guid;
    }
}