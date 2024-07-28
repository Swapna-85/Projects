using KeypadTracer.Settings;

namespace KeypadTracer.ChessPieces
{
    public sealed class Bishop(bool isWhitePiece) : ChessPieceBase(ChessPieceType.Bishop, isWhitePiece)
    {
        protected override List<char> GetValidDigitMovesForADigit(KeypadSettings keypad, int currentRow, int currentCol, IPhoneDigitValidator validator)
        {
            List<char> validDigits = [];
            // NW
            for (int i = currentRow - 1, j = currentCol - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (validator.IsDigitValid(i, j)) { validDigits.Add(keypad.Digits[i][j]); }
            }

            //SW
            for (int i = currentRow + 1, j = currentCol - 1; i < keypad.Rows && j >= 0; i++, j--)
            {
                if (validator.IsDigitValid(i, j)) { validDigits.Add(keypad.Digits[i][j]); }
            }

            //NE
            for (int i = currentRow - 1, j = currentCol + 1; i >= 0 && j < keypad.Columns; i--, j++)
            {
                if (validator.IsDigitValid(i, j)) { validDigits.Add(keypad.Digits[i][j]); }
            }

            //SE
            for (int i = currentRow + 1, j = currentCol + 1; i < keypad.Rows && j < keypad.Columns; i++, j++)
            {
                if (validator.IsDigitValid(i, j)) { validDigits.Add(keypad.Digits[i][j]); }
            }
            return validDigits;
        }

    }
}
