using ChessGame.Exceptions;

namespace ChessGame.Board;
public class GameBoard
{
    public int RowCount { get; set; }
    public int ColCount { get; set; }
    private Piece?[,] Pieces;

    public GameBoard()
    {
        RowCount = ChessGame.Shared.Constants.RowCount;
        ColCount = ChessGame.Shared.Constants.ColCount;
        Pieces = new Piece[8, 8];
    }

    public Piece? GetPiece(Position position)
    {
        if (IsValidPosition(position) == false)
            throw new BoardException("Invalid position");

        return Pieces[position.Row, position.Col];
    }

    public Piece? GetPiece(int row, int col)
    {
        return Pieces[row, col];
    }

    public void PlacePiece(Piece? piece, Position position)
    {
        if (HasPiece(position))
            throw new BoardException("This position already has a piece on it");

        piece?.SetBoard(this);
        Pieces[position.Row, position.Col] = piece;
        if (piece != null)
            piece.Position = position;
    }


    public Piece? RemovePiece(Position position)
    {
        if (GetPiece(position) == null)
            return null;
        var piece = GetPiece(position);
        if (piece != null)
            piece.Position = null;
        Pieces[position.Row, position.Col] = null;
        return piece;
    }

    public bool IsValidPosition(Position position)
    {
        if (position.Row < 0 || position.Row >= RowCount) return false;
        if (position.Col < 0 || position.Col >= ColCount) return false;
        return true;
    }

    private void HandlePosition(Position position)
    {
        if (!IsValidPosition(position))
            throw new BoardException("Invalid position");
    }

    private bool HasPiece(Position position)
    {
        HandlePosition(position);
        return Pieces[position.Row, position.Col] != null;
    }

}