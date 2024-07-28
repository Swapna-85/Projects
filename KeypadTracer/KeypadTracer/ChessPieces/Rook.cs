using KeypadTracer.Settings;

namespace KeypadTracer.ChessPieces
{
    public sealed class Rook(bool isWhitePiece) : ChessPieceBase(ChessPieceType.Rook, isWhitePiece)
    {
        protected override List<char> GetValidDigitMovesForADigit(KeypadSettings keypad, int currentRow, int currentCol, IPhoneDigitValidator validator)
        {
            List<char> validDigits = [];
            //move North 
            for (int i = currentRow - 1; i >= 0; i--)
            {
                if (validator.IsDigitValid(i, currentCol)) { validDigits.Add(keypad.Digits[i][currentCol]); }
            }

            //move South
            for (int i = currentRow + 1; i < keypad.Rows; i++)
            {

                if (validator.IsDigitValid(i, currentCol)) { validDigits.Add(keypad.Digits[i][currentCol]); }
            }

            //move West
            for (int i = currentCol - 1; i >= 0; i--)
            {
                if (validator.IsDigitValid(currentRow, i)) { validDigits.Add(keypad.Digits[currentRow][i]); }
            }

            //move East
            for (int i = currentCol + 1; i < keypad.Columns; i++)
            {
                if (validator.IsDigitValid(currentRow, i)) { validDigits.Add(keypad.Digits[currentRow][i]); }
            }
            return validDigits;
        }

    }
}
