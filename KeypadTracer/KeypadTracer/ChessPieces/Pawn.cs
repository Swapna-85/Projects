using KeypadTracer.Settings;

namespace KeypadTracer.ChessPieces
{
    public sealed class Pawn(bool isWhitePiece) : ChessPieceBase(ChessPieceType.Pawn, isWhitePiece)
    {
        protected override List<char> GetValidDigitMovesForADigit(KeypadSettings keypad, int currentRow, int currentCol, IPhoneDigitValidator validator)
        {
            List<char> validDigits = [];
            if (IsWhitePiece)
            {
                if (validator.IsDigitValid(currentRow - 1, currentCol)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol]); } // North
                if (validator.IsDigitValid(currentRow - 1, currentCol + 1)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol + 1]); } //North East
                if (validator.IsDigitValid(currentRow - 1, currentCol - 1)) { validDigits.Add(keypad.Digits[currentRow - 1][currentCol - 1]); } //NorthWest               
            }
            else
            {
                if (validator.IsDigitValid(currentRow + 1, currentCol)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol]); } //South
                if (validator.IsDigitValid(currentRow + 1, currentCol + 1)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol + 1]); } //South East
                if (validator.IsDigitValid(currentRow + 1, currentCol - 1)) { validDigits.Add(keypad.Digits[currentRow + 1][currentCol - 1]); } //South West
            }
            return validDigits;
        }
    }
}
