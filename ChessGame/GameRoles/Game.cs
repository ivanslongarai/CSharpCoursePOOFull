using ChessGame.Board;
using ChessGame.Board.Enums;
using ChessGame.Exceptions;

namespace ChessGame.GameRoles;

public class Game
{
    public GameBoard Board { get; private set; }
    public int TurnNumber { get; private set; }
    public EColor CurrentPlayer { get; private set; }
    public bool Finished { get; private set; }
    public Piece? CanTakeEnPassant { get; private set; }

    public HashSet<Piece> InGamePieces;
    public HashSet<Piece> CapturedPieces;

    public bool IsInCheck { get; set; }

    public Game()
    {
        CanTakeEnPassant = null;
        IsInCheck = false;
        Board = new GameBoard();
        TurnNumber = 1;
        CurrentPlayer = EColor.Blue;
        Finished = false;
        InGamePieces = new HashSet<Piece>();
        CapturedPieces = new HashSet<Piece>();
        StartPieces();
    }

    public void ExecPlay(Position origin, Position destiny)
    {
        var removedPiece = ExecMoviment(origin, destiny);
        if (IsKingInCheck(GetOpponentColor(CurrentPlayer)))
        {
            UndoMoviment(origin, destiny, removedPiece);
            ChangePlayer();
            IsInCheck = false;
            throw new BoardException("You cannot put yourself in CHECK");
        }

        Piece piece = Board!.GetPiece(destiny)!;

        // Special play
        // Promotion
        if (piece is Pawn)
        {
            if ((piece.Color == EColor.Blue && destiny.Row == 0) ||
                (piece.Color == EColor.Red && destiny.Row == 7))
            {
                piece = Board.RemovePiece(destiny)!;
                InGamePieces.Remove(piece);
                Queen queen = new Queen(piece.Color);
                Board.PlacePiece(queen, destiny);
                InGamePieces.Add(queen);
            }
        }

        TurnNumber++;

        // Special play
        // En Passant
        if (piece is Pawn && (destiny.Row == origin.Row - 2 ||
            destiny.Row == origin.Row + 2))
            CanTakeEnPassant = piece;
        else
            CanTakeEnPassant = null;

    }

    private void StartPieces()
    {
        PlaceNewPiece('a', 1, new Tower(EColor.Blue));
        PlaceNewPiece('b', 1, new Horse(EColor.Blue));
        PlaceNewPiece('c', 1, new Bishop(EColor.Blue));
        PlaceNewPiece('d', 1, new Queen(EColor.Blue));
        PlaceNewPiece('e', 1, new King(EColor.Blue, this));
        PlaceNewPiece('f', 1, new Bishop(EColor.Blue));
        PlaceNewPiece('g', 1, new Horse(EColor.Blue));
        PlaceNewPiece('h', 1, new Tower(EColor.Blue));
        PlaceNewPiece('a', 2, new Pawn(EColor.Blue, this));
        PlaceNewPiece('b', 2, new Pawn(EColor.Blue, this));
        PlaceNewPiece('c', 2, new Pawn(EColor.Blue, this));
        PlaceNewPiece('d', 2, new Pawn(EColor.Blue, this));
        PlaceNewPiece('e', 2, new Pawn(EColor.Blue, this));
        PlaceNewPiece('f', 2, new Pawn(EColor.Blue, this));
        PlaceNewPiece('g', 2, new Pawn(EColor.Blue, this));
        PlaceNewPiece('h', 2, new Pawn(EColor.Blue, this));

        PlaceNewPiece('a', 8, new Tower(EColor.Red));
        PlaceNewPiece('b', 8, new Horse(EColor.Red));
        PlaceNewPiece('c', 8, new Bishop(EColor.Red));
        PlaceNewPiece('d', 8, new Queen(EColor.Red));
        PlaceNewPiece('e', 8, new King(EColor.Red, this));
        PlaceNewPiece('f', 8, new Bishop(EColor.Red));
        PlaceNewPiece('g', 8, new Horse(EColor.Red));
        PlaceNewPiece('h', 8, new Tower(EColor.Red));
        PlaceNewPiece('a', 7, new Pawn(EColor.Red, this));
        PlaceNewPiece('b', 7, new Pawn(EColor.Red, this));
        PlaceNewPiece('c', 7, new Pawn(EColor.Red, this));
        PlaceNewPiece('d', 7, new Pawn(EColor.Red, this));
        PlaceNewPiece('e', 7, new Pawn(EColor.Red, this));
        PlaceNewPiece('f', 7, new Pawn(EColor.Red, this));
        PlaceNewPiece('g', 7, new Pawn(EColor.Red, this));
        PlaceNewPiece('h', 7, new Pawn(EColor.Red, this));
    }

    private Piece? ExecMoviment(Position origin, Position destiny)
    {
        Piece? p = Board.RemovePiece(origin);
        p?.IncMovesCount();
        var removedDestinyPiece = Board.RemovePiece(destiny);
        Board.PlacePiece(p, destiny);
        if (removedDestinyPiece != null)
            CapturedPieces.Add(removedDestinyPiece);

        //Changing player 
        CurrentPlayer = GetOpponentColor(CurrentPlayer);

        // Special play
        // Small Castling 
        if (p is King && destiny.Col == origin.Col + 2)
        {
            var towerOrigin = new Position(origin.Row, origin.Col + 3);
            var towerDestiny = new Position(origin.Row, origin.Col + 1);
            var tower = Board.RemovePiece(towerOrigin);
            tower!.IncMovesCount();
            Board.PlacePiece(tower, towerDestiny);
        }

        // Special play
        // Big Castling 
        if (p is King && destiny.Col == origin.Col - 2)
        {
            var towerOrigin = new Position(origin.Row, origin.Col - 4);
            var towerDestiny = new Position(origin.Row, origin.Col - 1);
            var tower = Board.RemovePiece(towerOrigin);
            tower!.IncMovesCount();
            Board.PlacePiece(tower, towerDestiny);
        }

        // Special play
        // En Passant
        if (p is Pawn)
        {
            if (origin.Col != destiny.Col && removedDestinyPiece == null)
            {
                Position pawnPosition;
                if (p.Color == EColor.Blue)
                    pawnPosition = new Position(destiny.Row + 1, destiny.Col);
                else
                    pawnPosition = new Position(destiny.Row - 1, destiny.Col);

                removedDestinyPiece = Board.RemovePiece(pawnPosition);
                CapturedPieces.Add(removedDestinyPiece!);
            }
        }

        return removedDestinyPiece;
    }

    private void UndoMoviment(Position origin, Position destiny, Piece? removedDestinyPiece)
    {
        var p = Board.RemovePiece(destiny);
        p?.DecMovesCount();
        if (removedDestinyPiece != null)
        {
            Board.PlacePiece(removedDestinyPiece, destiny);
            CapturedPieces.Remove(removedDestinyPiece);
        }
        Board.PlacePiece(p, origin);

        // Special play
        // Small Castling 
        if (p is King && destiny.Col == origin.Col + 2)
        {
            var towerOrigin = new Position(origin.Row, origin.Col + 3);
            var towerDestiny = new Position(origin.Row, origin.Col + 1);
            var tower = Board.RemovePiece(towerDestiny);
            tower!.DecMovesCount();
            Board.PlacePiece(tower, towerOrigin);
        }

        // Special play
        // Big Castling 
        if (p is King && destiny.Col == origin.Col - 2)
        {
            var towerOrigin = new Position(origin.Row, origin.Col - 4);
            var towerDestiny = new Position(origin.Row, origin.Col - 1);
            var tower = Board.RemovePiece(towerDestiny);
            tower!.DecMovesCount();
            Board.PlacePiece(tower, towerOrigin);
        }

        // Special play
        // En Passant
        if (p is Pawn)
        {
            if (origin.Col != destiny.Col && removedDestinyPiece == CanTakeEnPassant)
            {
                Piece pawnPiece = Board.RemovePiece(destiny)!;
                Position pawnPosition;
                if (p.Color == EColor.Blue)
                    pawnPosition = new Position(3, destiny.Col);
                else
                    pawnPosition = new Position(4, destiny.Col);
                Board.PlacePiece(pawnPiece, pawnPosition);
            }
        }
    }

    public void ValidateOriginPosition(Position position)
    {
        if (Board.GetPiece(position) == null)
            throw new BoardException("There is no piece at the informed position");

        if (CurrentPlayer != Board.GetPiece(position)!.Color)
            throw new BoardException("The informed piece is not yours");

        if (!Board.GetPiece(position)!.HaveAvailableMoviments())
            throw new BoardException("It's not possible to move that piece");
    }

    public void ValidateDestinyPosition(Position originPosition, Position destinyPosition)
    {
        if (!Board.GetPiece(originPosition)!.AvailableMoveToDestiny(destinyPosition))
            throw new BoardException("Invalid destiny position");
    }

    public void ChangePlayer()
    {
        if (CurrentPlayer == EColor.Blue)
            CurrentPlayer = EColor.Red;
        else
            CurrentPlayer = EColor.Blue;
    }

    public void PlaceNewPiece(char col, int row, Piece piece)
    {
        Board.PlacePiece(piece, new ChessPosition(col, row).ToPosition());
        InGamePieces.Add(piece);
    }

    public HashSet<Piece> GetCapturedPieces(EColor color)
    {
        HashSet<Piece> result = new HashSet<Piece>();
        foreach (var piece in CapturedPieces)
        {
            if (piece.Color == color)
                result.Add(piece);
        }
        return result;
    }

    public HashSet<Piece> GetInGamePieces(EColor color)
    {
        HashSet<Piece> result = new HashSet<Piece>();
        foreach (var piece in InGamePieces)
        {
            if (piece.Color == color)
                result.Add(piece);
        }
        result.ExceptWith(GetCapturedPieces(color));
        return result;
    }

    public EColor GetOpponentColor(EColor color)
    {
        if (color == EColor.Red)
            return EColor.Blue;
        return EColor.Red;
    }

    public Piece? GetKing(EColor color)
    {
        foreach (var piece in GetInGamePieces(color))
            if (piece is King)
                return piece;
        return null;
    }

    public bool IsKingInCheck(EColor color)
    {
        var king = GetKing(color);
        foreach (var piece in GetInGamePieces(GetOpponentColor(color)))
        {
            var matrix = piece.AvailableMoviments();
            if (matrix[king!.Position!.Row, king!.Position!.Col])
            {
                IsInCheck = true;
                return true;
            }

        }
        IsInCheck = false;
        return false;
    }

    public bool IsTheEnd(EColor color)
    {
        if (!IsKingInCheck(color))
            return false;
        foreach (var piece in GetInGamePieces(color))
        {
            var matrix = piece.AvailableMoviments();
            for (var i = 0; i < Board.RowCount; i++)
            {
                for (var y = 0; y < Board.ColCount; y++)
                {
                    if (matrix[i, y] == true)
                    {
                        var destiny = new Position(i, y);
                        var capturedPiece = ExecMoviment(piece.Position!, destiny);
                        var checkTest = IsKingInCheck(color);
                        UndoMoviment(piece.Position!, destiny, capturedPiece);
                        if (checkTest == false)
                            return false;
                    }
                }
            }
        }
        Finished = true;
        return true;
    }

}