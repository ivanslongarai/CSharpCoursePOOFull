using ChessGame.Board;
using ChessGame.Board.Enums;

namespace ChessGame.GameRoles;

public class Pawn : Piece
{
    private Game _play;
    public Pawn(EColor color, Game play) : base(color)
    {
        _play = play;
    }

    public override string ToString() => "P";

    private bool HasEnemy(Position position)
    {
        var piece = Board!.GetPiece(position);
        return piece != null && piece.Color != Color;
    }

    private bool IsFree(Position position)
    {
        return Board!.GetPiece(position) == null;
    }

    public override bool[,] AvailableMoviments()
    {
        var matrix = new bool[Board!.RowCount, Board.ColCount];
        var pos = new Position(0, 0);

        if (Color == EColor.Blue)
        {
            CopyThisPosition(pos);
            pos.DefineValues(pos.Row - 1, pos.Col);
            if (Board.IsValidPosition(pos) && IsFree(pos))
                matrix[pos.Row, pos.Col] = true;

            CopyThisPosition(pos);
            pos.DefineValues(pos.Row - 2, pos.Col);
            if (Board.IsValidPosition(pos) && IsFree(pos) && MovesCount == 0)
                matrix[pos.Row, pos.Col] = true;

            CopyThisPosition(pos);
            pos.DefineValues(pos.Row - 1, pos.Col - 1);
            if (Board.IsValidPosition(pos) && HasEnemy(pos))
                matrix[pos.Row, pos.Col] = true;

            CopyThisPosition(pos);
            pos.DefineValues(pos.Row - 1, pos.Col + 1);
            if (Board.IsValidPosition(pos) && HasEnemy(pos))
                matrix[pos.Row, pos.Col] = true;

            // Special play
            // En Passant
            CopyThisPosition(pos);
            if (Position!.Row == 3)
            {
                var leftPosition = new Position(Position.Row, Position.Col - 1);
                if (Board.IsValidPosition(leftPosition) &&
                    HasEnemy(leftPosition) &&
                    Board.GetPiece(leftPosition) == _play.CanTakeEnPassant)
                {
                    matrix[leftPosition.Row - 1, leftPosition.Col] = true;
                }

                var rightPosition = new Position(Position.Row, Position.Col + 1);
                if (Board.IsValidPosition(rightPosition) &&
                    HasEnemy(rightPosition) &&
                    Board.GetPiece(rightPosition) == _play.CanTakeEnPassant)
                {
                    matrix[rightPosition.Row - 1, rightPosition.Col] = true;
                }
            }

        }
        else
        {
            CopyThisPosition(pos);
            pos.DefineValues(pos.Row + 1, pos.Col);
            if (Board.IsValidPosition(pos) && IsFree(pos))
                matrix[pos.Row, pos.Col] = true;

            CopyThisPosition(pos);
            pos.DefineValues(pos.Row + 2, pos.Col);
            if (Board.IsValidPosition(pos) && IsFree(pos) && MovesCount == 0)
                matrix[pos.Row, pos.Col] = true;

            CopyThisPosition(pos);
            pos.DefineValues(pos.Row + 1, pos.Col - 1);
            if (Board.IsValidPosition(pos) && HasEnemy(pos))
                matrix[pos.Row, pos.Col] = true;

            CopyThisPosition(pos);
            pos.DefineValues(pos.Row + 1, pos.Col + 1);
            if (Board.IsValidPosition(pos) && HasEnemy(pos))
                matrix[pos.Row, pos.Col] = true;

            // Special play
            // En Passant
            CopyThisPosition(pos);
            if (Position!.Row == 4)
            {
                var leftPosition = new Position(Position.Row, Position.Col - 1);
                if (Board.IsValidPosition(leftPosition) &&
                    HasEnemy(leftPosition) &&
                    Board.GetPiece(leftPosition) == _play.CanTakeEnPassant)
                {
                    matrix[leftPosition.Row + 1, leftPosition.Col] = true;
                }

                var rightPosition = new Position(Position.Row, Position.Col + 1);
                if (Board.IsValidPosition(rightPosition) &&
                    HasEnemy(rightPosition) &&
                    Board.GetPiece(rightPosition) == _play.CanTakeEnPassant)
                {
                    matrix[rightPosition.Row + 1, rightPosition.Col] = true;
                }
            }

        }

        return matrix;
    }
}