using ChessGame.Board.Enums;

namespace ChessGame.Shared;

public static class Functions
{
    public static void PrintColorText(string text, EColor color, bool breakLine = false)
    {

        var backupColor = Console.ForegroundColor;

        switch (color)
        {
            case EColor.Red:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case EColor.Blue:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case EColor.Yellow:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }

        if (breakLine == true)
            Console.WriteLine(text);
        else
            Console.Write(text);

        Console.ForegroundColor = backupColor;
    }

    public static void PrintColorText(object obj, EColor color, bool breakLine = false)
    {

        var backupColor = Console.ForegroundColor;

        switch (color)
        {
            case EColor.Red:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case EColor.Blue:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case EColor.Yellow:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }

        if (breakLine == true)
            Console.WriteLine(obj);
        else
            Console.Write(obj);

        Console.ForegroundColor = backupColor;
    }
}