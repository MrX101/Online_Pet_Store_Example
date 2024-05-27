using System.Diagnostics;

namespace Online_Pet_Store_Example;

public static class Logger
{
    public static void Log(string text)
    {
        Console.WriteLine(text);
        Debug.WriteLine(text);
    }
}