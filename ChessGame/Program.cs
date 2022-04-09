using ChessGame.Application;
using ChessGame.Board;
using ChessGame.Exceptions;
using ChessGame.GameRoles;

Console.Clear();
var play = new Game();

while (!play.Finished)
{

    Console.Clear();

    Position destiny;
    Position origin;

    if (!Screen.PrintPlay(play))
        return;

    Console.Write("Origin: ");
    try
    {
        origin = Screen.ReadChessPosition()!.ToPosition();
        play.ValidateOriginPosition(origin);
    }
    catch (BoardException ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        continue;
    }

    var avaliablePositions = play.Board.GetPiece(origin)!.AvailableMoviments();
    Console.Clear();
    Screen.PrintBoard(play.Board, avaliablePositions);

    Console.WriteLine();
    Console.WriteLine();
    Console.Write("Destiny: ");
    try
    {
        destiny = Screen.ReadChessPosition()!.ToPosition();
        play.ValidateDestinyPosition(origin, destiny);
    }
    catch (BoardException ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        continue;
    }

    try
    {
        play.ExecPlay(origin, destiny);
    }
    catch (BoardException ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }

}

Console.Clear();
Screen.PrintPlay(play);
Console.WriteLine();
Console.WriteLine();
Console.ReadKey();