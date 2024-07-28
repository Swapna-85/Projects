namespace KeypadTracer.ChessPieces
{
    public class ChessPieceFactory : IChessPieceFactory
    {
        public ChessPieceBase GetChessPiece(ChessPieceType type, bool isWhitePiece)
        {
            return type switch
            {
                ChessPieceType.King => new King(isWhitePiece),
                ChessPieceType.Knight => new Knight(isWhitePiece),
                ChessPieceType.Queen => new Queen(isWhitePiece),
                ChessPieceType.Rook => new Rook(isWhitePiece),
                ChessPieceType.Bishop => new Bishop(isWhitePiece),
                ChessPieceType.Pawn => new Pawn(isWhitePiece),
                _ => throw new ArgumentOutOfRangeException($"Invalid value {type} specified for {nameof(type)}"),
            };
        }
    }
}
