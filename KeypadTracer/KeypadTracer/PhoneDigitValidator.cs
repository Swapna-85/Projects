using KeypadTracer.Settings;
using Microsoft.Extensions.Configuration;

namespace KeypadTracer
{
    public class PhoneDigitValidator : IPhoneDigitValidator
    {
        public KeypadSettings KeypadSettings { get; init; }

        public PhoneNumberSettings PhoneNumberSettings { get; init; }

        public PhoneDigitValidator(IConfiguration config)
        {

            KeypadSettings = config.GetSection("Keypad").Get<KeypadSettings>();
            PhoneNumberSettings = config.GetSection("PhoneNumber").Get<PhoneNumberSettings>();
        }

        /// <summary>
        /// Check if the keypad digit at the given row and column is valid.
        /// </summary>
        ///<remarks>
        ///The digit validity depends on the keypad and phone number settings.
        ///This includes the key pad rows, columns,digits and phone number invalid digits.
        ///</remarks>
        public bool IsDigitValid(int row, int column)
        {
            if (row < 0 || row >= KeypadSettings.Rows) { return false; }
            if (column < 0 || column >= KeypadSettings.Columns) { return false; }
            if (PhoneNumberSettings.InvalidDigits != null && PhoneNumberSettings.InvalidDigits.Contains(KeypadSettings.Digits[row][column])) { return false; }
            return true;
        }
    }
}
