using KeypadTracer.ChessPieces;

namespace KeypadTracer
{
    public interface IKeypadTracer
    {
        /// <summary>
        /// Gets valid phone number combination count for the given chess piece.
        /// </summary>
        public int GetValidPhoneNumberCombinationCount(ChessPieceBase chessPiece);
    }
}
