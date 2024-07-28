using KeypadTracer.Settings;

namespace KeypadTracer.ChessPieces
{
    public sealed class King(bool isWhitePiece) : ChessPieceBase(ChessPieceType.King, isWhitePiece)
    {
        protected override List<char> GetValidDigitMovesForADigit(KeypadSettings keypad, int currentRow, int currentCol, IPhoneDigitValidator validator)
        {
            List<char> validDigits = [];
            if (validator.IsDigitValid(currentRow + 1, currentCol)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol]); } //South
            if (validator.IsDigitValid(currentRow - 1, currentCol)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol]); } // North
            if (validator.IsDigitValid(currentRow, currentCol + 1)) { validDigits.Add(keypad.Digits[currentRow][currentCol + 1]); } //East
            if (validator.IsDigitValid(currentRow, currentCol - 1)) { validDigits.Add(keypad.Digits[currentRow][currentCol - 1]); } //West
            if (validator.IsDigitValid(currentRow + 1, currentCol + 1)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol + 1]); } //South East
            if (validator.IsDigitValid(currentRow + 1, currentCol - 1)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol - 1]); } //South West
            if (validator.IsDigitValid(currentRow - 1, currentCol + 1)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol + 1]); } //North East
            if (validator.IsDigitValid(currentRow - 1, currentCol - 1)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol - 1]); } //NorthWest
            return validDigits;
        }
    }
}
