using ChessGame.Board;
using ChessGame.Board.Enums;

namespace ChessGame.GameRoles;

public class King : Piece
{
    private Game _play { get; set; }

    public King(EColor color, Game play) : base(color)
    {
        _play = play;
    }

    public override string ToString()
    {
        return "K";
    }

    public override bool[,] AvailableMoviments()
    {
        var matrix = new bool[Board!.RowCount, Board.ColCount];

        var pos = new Position(0, 0);

        //Up
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row - 1, pos.Col);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        //Up-Rigth
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row - 1, pos.Col + 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        //Right
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row, pos.Col + 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        //Down-Right
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 1, pos.Col + 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        //Down
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 1, pos.Col);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        //Down-Left
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row + 1, pos.Col - 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        //Left
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row, pos.Col - 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        //Up-Left
        CopyThisPosition(pos);
        pos.DefineValues(pos.Row - 1, pos.Col - 1);
        if (Board.IsValidPosition(pos) && CanMove(pos))
        {
            matrix[pos.Row, pos.Col] = true;
        }

        // Special play
        // Small Castling 
        CopyThisPosition(pos);
        if (MovesCount == 0 && _play.IsInCheck == false)
        {
            var towerPos = new Position(pos.Row, pos.Col + 3);
            if (CanTowerCastling(towerPos))
            {
                var emptyFirst = new Position(pos.Row, pos.Col + 1);
                var emptySecound = new Position(pos.Row, pos.Col + 2);
                if (Board.GetPiece(emptyFirst) == null && Board.GetPiece(emptySecound) == null)
                {
                    matrix[pos.Row, pos.Col + 2] = true;
                }
            }
        }

        // Special play
        // Big Castling 
        CopyThisPosition(pos);
        if (MovesCount == 0 && _play.IsInCheck == false)
        {
            var towerPos = new Position(pos.Row, pos.Col - 4);
            if (CanTowerCastling(towerPos))
            {
                var emptyFirst = new Position(pos.Row, pos.Col - 1);
                var emptySecound = new Position(pos.Row, pos.Col - 2);
                var emptyThird = new Position(pos.Row, pos.Col - 3);
                if (Board.GetPiece(emptyFirst) == null && Board.GetPiece(emptySecound) == null
                    && Board.GetPiece(emptyThird) == null)
                {
                    matrix[pos.Row, pos.Col - 2] = true;
                }
            }
        }

        return matrix;
    }

    private bool CanTowerCastling(Position position)
    {
        var piece = Board!.GetPiece(position);
        return piece != null && piece is Tower && piece.Color == Color && piece.MovesCount == 0;
    }
}