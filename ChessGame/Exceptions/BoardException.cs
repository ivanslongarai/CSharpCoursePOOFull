using System;
namespace ChessGame.Exceptions;

public class BoardException : Exception
{
    public BoardException(string message) : base(message) { }
}