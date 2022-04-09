using System.Drawing;
using ChessGame.Board.Enums;

namespace ChessGame.Board;

public abstract class Piece
{
    public Piece(EColor color)
    {
        this.Position = null;
        this.Board = null;
        this.Color = color;
        this.MovesCount = 0;
    }

    public Position? Position { get; set; }
    public EColor Color { get; protected set; }
    public GameBoard? Board { get; protected set; }
    public int MovesCount { get; protected set; }

    public void SetBoard(GameBoard board)
    {
        Board = board;
    }

    protected virtual bool CanMove(Position position)
    {
        var p = Board?.GetPiece(position);
        return p == null || p.Color != this.Color;
    }

    public void IncMovesCount() => MovesCount++;
    public void DecMovesCount() => MovesCount--;

    public abstract bool[,] AvailableMoviments();

    protected void CopyThisPosition(Position? position)
    {
        position!.Row = this.Position!.Row;
        position.Col = this.Position!.Col;
    }

    public bool HaveAvailableMoviments()
    {
        bool[,] matrix = AvailableMoviments();
        for (var i = 0; i < Board!.RowCount; i++)
        {
            for (var y = 0; y < Board!.ColCount; y++)
            {
                if (matrix[i, y] == true)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool AvailableMoveToDestiny(Position position)
    {
        return AvailableMoviments()[position.Row, position.Col] == true;
    }

}