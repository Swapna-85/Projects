using FluentAssertions;
using KeypadTracer.ChessPieces;
using Microsoft.Extensions.Configuration;

namespace KeypadTracer.Tests
{
    [TestFixture]
    public class KeypadTests
    {

        private IConfiguration _config;
        private IPhoneDigitValidator _validator;
        public KeypadTests()
        {
            _config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.Tests.json")
               .Build();
            _validator = new PhoneDigitValidator(_config);
        }


        [Test]
        public void CheckChessPiecePhoneNumberCombinationReturnsCorrectCount()
        {

            //Arrange
            KeypadTracer keypad = new KeypadTracer(_validator, _config);
            IChessPieceFactory chesspieceFactory = new ChessPieceFactory();


            //Act & Assert
            ChessPieceBase rook = chesspieceFactory.GetChessPiece(ChessPieceType.Rook, isWhitePiece: true);
            int rookCount = keypad.GetValidPhoneNumberCombinationCount(rook);
            rookCount.Should().Be(49326);

            ChessPieceBase bishop = chesspieceFactory.GetChessPiece(ChessPieceType.Bishop, isWhitePiece: true);
            int bishopCount = keypad.GetValidPhoneNumberCombinationCount(bishop);
            bishopCount.Should().Be(2341);

            ChessPieceBase knight = chesspieceFactory.GetChessPiece(ChessPieceType.Knight, isWhitePiece: true);
            int knightCount = keypad.GetValidPhoneNumberCombinationCount(knight);
            knightCount.Should().Be(952);

            ChessPieceBase king = chesspieceFactory.GetChessPiece(ChessPieceType.King, isWhitePiece: true);
            int kingCount = keypad.GetValidPhoneNumberCombinationCount(king);
            kingCount.Should().Be(124908);

            ChessPieceBase queen = chesspieceFactory.GetChessPiece(ChessPieceType.Queen, isWhitePiece: true);
            int queenCount = keypad.GetValidPhoneNumberCombinationCount(queen);
            queenCount.Should().Be(751503);

            ChessPieceBase whitePawn = chesspieceFactory.GetChessPiece(ChessPieceType.Pawn, isWhitePiece: true);
            int whitePawnCount = keypad.GetValidPhoneNumberCombinationCount(whitePawn);
            whitePawnCount.Should().Be(0);

            ChessPieceBase blackPawn = chesspieceFactory.GetChessPiece(ChessPieceType.Pawn, isWhitePiece: false);
            int blackPawnCount = keypad.GetValidPhoneNumberCombinationCount(blackPawn);
            blackPawnCount.Should().Be(0);

        }
    }
}