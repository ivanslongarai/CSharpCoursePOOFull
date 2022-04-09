using ChessGame.Board;

namespace ChessGame.GameRoles;

public class ChessPosition
{
    public ChessPosition(char col, int row)
    {
        this.Col = col;
        this.Row = row;
    }

    public char Col { get; set; }
    public int Row { get; set; }

    public override string ToString()
    {
        return "" + Col + Row;
    }

    public Position ToPosition()
    {
        return new Position(ChessGame.Shared.Constants.RowCount - Row, Col - 'a');
    }
}