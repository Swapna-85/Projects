using KeypadTracer.ChessPieces;
using KeypadTracer.Settings;
using Microsoft.Extensions.Configuration;

namespace KeypadTracer
{
    public sealed class KeypadTracer : IKeypadTracer
    {
        public KeypadSettings KeypadSettings { get; init; }

        public PhoneNumberSettings PhoneNumberSettings { get; init; }

        public IPhoneDigitValidator PhoneDigitValidator { get; init; }

        public KeypadTracer(IPhoneDigitValidator validator, IConfiguration config)
        {
            PhoneDigitValidator = validator;
            KeypadSettings = config.GetSection("Keypad").Get<KeypadSettings>();
            PhoneNumberSettings = config.GetSection("PhoneNumber").Get<PhoneNumberSettings>();
        }

        /// <summary>
        /// Gets valid phone number combination count for the given chess piece 
        /// </summary>
        ///<remarks>
        ///The valid combination takes into consideration the phone number length,invalid digits and start digits configuration.
        ///</remarks>
        public int GetValidPhoneNumberCombinationCount(ChessPieceBase chessPiece)
        {
            int combinationCounter = 0;
            Dictionary<char, List<char>> keypadMoves = chessPiece.GetValidDigitMoves(KeypadSettings, PhoneDigitValidator!);
            foreach (var startKey in keypadMoves.Keys)
            {
                if (PhoneNumberSettings!.InvalidStartDigits != null && PhoneNumberSettings!.InvalidStartDigits.Contains(startKey)) { continue; }
                GeneratePhoneNumbers(keypadMoves, new LinkedList<char>([startKey]), PhoneNumberSettings.RequiredLength, ref combinationCounter);
            }
            return combinationCounter;
        }


        private static void GeneratePhoneNumbers(Dictionary<char, List<char>> keypadMoves, LinkedList<char> currentSequence, int targetLength, ref int counter)
        {
            if (currentSequence.Count == targetLength)
            {
                counter++;
                return;
            }

            char lastKey = currentSequence.Last!.Value;
            foreach (var nextKey in keypadMoves[lastKey])
            {
                currentSequence.AddLast(nextKey);
                GeneratePhoneNumbers(keypadMoves, currentSequence, targetLength, ref counter);
                currentSequence.RemoveLast(); // Backtrack
            }
        }
    }
}
