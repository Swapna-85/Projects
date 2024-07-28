using KeypadTracer.Settings;

namespace KeypadTracer.ChessPieces
{
    public sealed class Knight(bool isWhitePiece) : ChessPieceBase(ChessPieceType.Knight, isWhitePiece)
    {
        protected override List<char> GetValidDigitMovesForADigit(KeypadSettings keypad, int currentRow, int currentCol, IPhoneDigitValidator validator)
        {
            List<char> validDigits = [];
            if (validator.IsDigitValid(currentRow + 2, currentCol + 1)) { validDigits.Add(keypad.Digits[currentRow + 2][currentCol + 1]); }
            if (validator.IsDigitValid(currentRow + 2, currentCol - 1)) { validDigits.Add(keypad.Digits[currentRow + 2][currentCol - 1]); }
            if (validator.IsDigitValid(currentRow - 2, currentCol + 1)) { validDigits.Add(keypad.Digits[currentRow - 2][currentCol + 1]); }
            if (validator.IsDigitValid(currentRow - 2, currentCol - 1)) { validDigits.Add(keypad.Digits[currentRow - 2][currentCol - 1]); }

            if (validator.IsDigitValid(currentRow + 1, currentCol + 2)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol + 2]); }
            if (validator.IsDigitValid(currentRow + 1, currentCol - 2)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol - 2]); }
            if (validator.IsDigitValid(currentRow - 1, currentCol + 2)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol + 2]); }
            if (validator.IsDigitValid(currentRow - 1, currentCol - 2)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol - 2]); }

            return validDigits;
        }
    }
}
