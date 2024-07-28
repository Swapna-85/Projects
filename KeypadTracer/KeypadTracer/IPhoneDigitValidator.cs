namespace KeypadTracer
{
    public interface IPhoneDigitValidator
    {
        /// <summary>
        /// Check if the keypad digit at the given row and column is valid
        /// </summary>
        bool IsDigitValid(int row, int column);

    }
}
