//TODO: gamelogger system that will be inyected using DI
using System;

public class GameLogger()
{
    public void Log(string message)
    {
        //This is helpful if I want to change the logging mechanism later (e.g., to a file, history system, etc.)
        //I can also modify the log logic globally since it has to be consistent
        Console.WriteLine($"[GameLog] : {message}");
    }
}