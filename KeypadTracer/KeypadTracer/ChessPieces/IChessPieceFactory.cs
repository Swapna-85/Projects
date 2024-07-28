namespace KeypadTracer.ChessPieces
{
    public interface IChessPieceFactory
    {
        /// <summary>
        /// Get Chess piece for the given type
        /// </summary>
        public ChessPieceBase GetChessPiece(ChessPieceType type, bool isWhitePiece);
    }
}
