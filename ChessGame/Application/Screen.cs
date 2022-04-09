using ChessGame.Board;
using ChessGame.Board.Enums;
using ChessGame.Exceptions;
using ChessGame.GameRoles;
using ChessGame.Shared;

namespace ChessGame.Application;

public class Screen
{
    public static void PrintBoard(GameBoard board)
    {
        for (var i = 0; i < board.RowCount; i++)
        {
            Functions.PrintColorText(ChessGame.Shared.Constants.ColCount - i + " ", EColor.Yellow);
            for (var y = 0; y < board.ColCount; y++)
            {
                var pieceValue = board.GetPiece(i, y);
                if (pieceValue == null)
                    Console.Write("- ");
                else
                {
                    PrintPiece(pieceValue);
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        Functions.PrintColorText("  a b c d e f g h", EColor.Yellow);
    }

    public static bool PrintPlay(Game play)
    {
        //Print the board
        Screen.PrintBoard(play.Board);

        Console.WriteLine();
        Console.WriteLine();

        //Print Captured Pieces
        PrintCapturedPieces(play);

        //Print Turn
        Console.WriteLine($"Turn: {play.TurnNumber}");

        if (!play.IsTheEnd(play.CurrentPlayer))
        {
            //Continue playing

            Functions.PrintColorText($"Waiting for the player: {play.CurrentPlayer}", play.CurrentPlayer, true);
            var isInCheck = play.IsKingInCheck(play.CurrentPlayer);
            if (isInCheck)
                Functions.PrintColorText("You are in Check", play.CurrentPlayer);

            Console.WriteLine();
            return true;
        }
        else
        {
            //EndGame
            Functions.PrintColorText("CHECKMATE", play.CurrentPlayer, true);
            Functions.PrintColorText($"Winner is: {play.CurrentPlayer}", play.CurrentPlayer, true);
            return false;
        }
    }

    private static void PrintCapturedPieces(Game play)
    {
        Console.WriteLine("Captured Pieces:");

        //Print Captured pieces for Blue
        Functions.PrintColorText("Blue: ", play.CurrentPlayer);
        PrintSet(play.GetCapturedPieces(EColor.Blue), EColor.Blue);
        Console.WriteLine();

        //Print Captured pieces for Red
        Functions.PrintColorText("Red: ", play.GetOpponentColor(play.CurrentPlayer));
        PrintSet(play.GetCapturedPieces(EColor.Red), EColor.Red);
        Console.WriteLine();

        Console.WriteLine();
    }

    private static void PrintSet(HashSet<Piece> setOfPieces, EColor color)
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
        }

        Console.Write("[");
        foreach (var piece in setOfPieces)
            Console.Write($"{piece} ");
        Console.Write("]");

        Console.ForegroundColor = backupColor;
    }

    public static void PrintBoard(GameBoard board, bool[,] availableMoviments)
    {
        var originalBackgroundColor = Console.BackgroundColor;
        var possibleMovimentsColor = ConsoleColor.DarkGray;

        for (var i = 0; i < board.RowCount; i++)
        {
            Functions.PrintColorText(ChessGame.Shared.Constants.ColCount - i + " ", EColor.Yellow);
            for (var y = 0; y < board.ColCount; y++)
            {
                if (availableMoviments[i, y] == true)
                    Console.BackgroundColor = possibleMovimentsColor;
                else
                    Console.BackgroundColor = originalBackgroundColor;

                var pieceValue = board.GetPiece(i, y);
                if (pieceValue == null)
                    Console.Write("- ");
                else
                {
                    PrintPiece(pieceValue);
                    Console.Write(" ");
                }
                Console.BackgroundColor = originalBackgroundColor;
            }
            Console.WriteLine();
        }
        Console.BackgroundColor = originalBackgroundColor;
        Functions.PrintColorText("  a b c d e f g h", EColor.Yellow);
    }

    public static void PrintPiece(Piece piece)
    {
        if (piece.Color == EColor.Red)
            Functions.PrintColorText(piece, EColor.Red);
        else
            Functions.PrintColorText(piece, EColor.Blue);
    }

    public static ChessPosition? ReadChessPosition()
    {
        try
        {
            string? s = Console.ReadLine();
            int row;
            char col;
            if (s != null)
            {
                col = s[0];
                row = int.Parse(s[1] + "");
                return new ChessPosition(col, row);
            }
            return null;
        }
        catch
        {
            throw new BoardException("Invalid position");
        }
    }

}