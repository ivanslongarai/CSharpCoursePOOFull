using ChessGame.Board;
using ChessGame.Board.Enums;

namespace ChessGame.GameRoles;

public class Tower : Piece
{
    public Tower(EColor color) : base(color) { }

    public override string ToString()
    {
        return "T";
    }

    public override bool[,] AvailableMoviments()
    {
        var matrix = new bool[Board!.RowCount, Board.ColCount];
        var pos = new Position(0, 0);

        //Up
        CopyThisPosition(pos);
        pos?.DefineValues(pos.Row - 1, pos.Col);
        while (Board.IsValidPosition(pos!) && CanMove(pos!))
        {
            matrix[pos!.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.Row--;
        }

        //Down
        CopyThisPosition(pos);
        pos!.DefineValues(pos.Row + 1, pos.Col);
        while (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.Row++;
        }

        //Right
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row, pos.Col + 1);
        while (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.Col++;
        }

        //Left
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row, pos.Col - 1);
        while (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.Col--;
        }

        return matrix;
    }

}