using ChessGame.Board;
using ChessGame.Board.Enums;

namespace ChessGame.GameRoles;

public class Queen : Piece
{
    public Queen(EColor color) : base(color)
    {

    }

    public override string ToString()
    {
        return "Q";
    }

    public override bool[,] AvailableMoviments()
    {
        var matrix = new bool[Board!.RowCount, Board.ColCount];
        var pos = new Position(0, 0);

        //Left
        CopyThisPosition(pos);
        pos?.DefineValues(pos.Row, pos.Col - 1);
        while (Board.IsValidPosition(pos!) && CanMove(pos!))
        {
            matrix[pos!.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row, pos.Col - 1);
        }

        //Right
        CopyThisPosition(pos);
        pos?.DefineValues(pos.Row, pos.Col + 1);
        while (Board.IsValidPosition(pos!) && CanMove(pos!))
        {
            matrix[pos!.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row, pos.Col + 1);
        }

        //Up
        CopyThisPosition(pos);
        pos?.DefineValues(pos.Row - 1, pos.Col);
        while (Board.IsValidPosition(pos!) && CanMove(pos!))
        {
            matrix[pos!.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row - 1, pos.Col);
        }

        //Down
        CopyThisPosition(pos);
        pos?.DefineValues(pos.Row + 1, pos.Col);
        while (Board.IsValidPosition(pos!) && CanMove(pos!))
        {
            matrix[pos!.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row + 1, pos.Col);
        }

        //Up-Left
        CopyThisPosition(pos);
        pos?.DefineValues(pos.Row - 1, pos.Col - 1);
        while (Board.IsValidPosition(pos!) && CanMove(pos!))
        {
            matrix[pos!.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row - 1, pos.Col - 1);
        }

        //Up-Right
        CopyThisPosition(pos);
        pos!.DefineValues(pos.Row - 1, pos.Col + 1);
        while (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row - 1, pos.Col + 1);
        }

        //Down-Left
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 1, pos.Col - 1);
        while (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row + 1, pos.Col - 1);
        }

        //Down-Right
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 1, pos.Col - 1);
        while (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
            if (Board.GetPiece(pos) != null && Board!.GetPiece(pos)!.Color != this.Color)
                break;
            pos.DefineValues(pos.Row + 1, pos.Col - 1);
        }

        return matrix;
    }
}