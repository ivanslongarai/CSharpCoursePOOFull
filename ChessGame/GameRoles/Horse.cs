using ChessGame.Board;
using ChessGame.Board.Enums;

namespace ChessGame.GameRoles;

public class Horse : Piece
{
    public Horse(EColor color) : base(color)
    {

    }

    public override string ToString()
    {
        return "H";
    }

    public override bool[,] AvailableMoviments()
    {
        var matrix = new bool[Board!.RowCount, Board.ColCount];

        var pos = new Position(0, 0);

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row - 1, pos.Col - 2);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row - 2, pos.Col - 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row - 2, pos.Col + 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row - 1, pos.Col + 2);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 1, pos.Col + 2);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 2, pos.Col + 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 2, pos.Col - 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 1, pos.Col - 2);
        if (Board.IsValidPosition(pos) && CanMove(pos))
            matrix[pos.Row, pos.Col] = true;

        return matrix;
    }
}