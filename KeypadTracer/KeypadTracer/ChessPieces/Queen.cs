using KeypadTracer.Settings;

namespace KeypadTracer.ChessPieces
{
    public sealed class Queen(bool isWhitePiece) : ChessPieceBase(ChessPieceType.Queen, isWhitePiece)
    {
        protected override List<char> GetValidDigitMovesForADigit(KeypadSettings keypad, int currentRow, int currentCol, IPhoneDigitValidator validator)
        {
            List<char> validDigits = [];
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
                if (validator.IsDigitValid(currentRow, i))
                {
                    validDigits.Add(keypad.Digits[currentRow][i]);
                }
            }

            //move East
            for (int i = currentCol + 1; i < keypad.Columns; i++)
            {
                if (validator.IsDigitValid(currentRow, i))
                {
                    validDigits.Add(keypad.Digits[currentRow][i]);
                }
            }
            // NW
            for (int i = currentRow - 1, j = currentCol - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (validator.IsDigitValid(i, j))
                {
                    validDigits.Add(keypad.Digits[i][j]);
                }
            }

            //SW
            for (int i = currentRow + 1, j = currentCol - 1; i < keypad.Rows && j >= 0; i++, j--)
            {
                if (validator.IsDigitValid(i, j))
                {
                    validDigits.Add(keypad.Digits[i][j]);
                }
            }

            //NE
            for (int i = currentRow - 1, j = currentCol + 1; i >= 0 && j < keypad.Columns; i--, j++)
            {
                if (validator.IsDigitValid(i, j))
                {
                    validDigits.Add(keypad.Digits[i][j]);
                }
            }

            //SE
            for (int i = currentRow + 1, j = currentCol + 1; i < keypad.Rows && j < keypad.Columns; i++, j++)
            {
                if (validator.IsDigitValid(i, j))
                {
                    validDigits.Add(keypad.Digits[i][j]);
                }
            }
            return validDigits;
        }


    }
}
