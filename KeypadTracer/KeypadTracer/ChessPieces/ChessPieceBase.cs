using KeypadTracer.Settings;

namespace KeypadTracer.ChessPieces
{
    public abstract class ChessPieceBase
    {

        public ChessPieceType Type { get; init; }
        public bool IsWhitePiece { get; init; }

        public ChessPieceBase(ChessPieceType type, bool isWhitePiece)
        {
            Type = type;
            IsWhitePiece = isWhitePiece;
        }

        /// <summary>
        /// Gets next possible digits corresponding to each keypad digit based on the chess piece valid moves.
        /// </summary>
        public Dictionary<char, List<char>> GetValidDigitMoves(KeypadSettings keypad, IPhoneDigitValidator validator)
        {
            Dictionary<char, List<char>> validNextDigits = [];
            for (int r = 0; r < keypad.Rows; r++)
            {
                for (int c = 0; c < keypad.Columns; c++)
                {
                    char digit = keypad.Digits[r][c];
                    if (validator.IsDigitValid(r, c))
                    {
                        validNextDigits.Add(digit, []);
                        validNextDigits[digit].AddRange(GetValidDigitMovesForADigit(keypad, r, c, validator));
                    }
                }
            }
            return validNextDigits;
        }

        protected abstract List<char> GetValidDigitMovesForADigit(KeypadSettings keypad, int currentRow, int currentCol, IPhoneDigitValidator validator);

    }
}
