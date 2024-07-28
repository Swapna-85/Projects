using FluentAssertions;
using KeypadTracer.ChessPieces;

namespace KeypadTracer.Tests
{
    [TestFixture]
    public class ChessPieceFactoryTests
    {

        private IChessPieceFactory _factory;


        public ChessPieceFactoryTests()
        {
            _factory = new ChessPieceFactory();
        }


        [TestCase(ChessPieceType.King, true, typeof(King))]
        [TestCase(ChessPieceType.King, false, typeof(King))]
        [TestCase(ChessPieceType.Knight, true, typeof(Knight))]
        [TestCase(ChessPieceType.Knight, false, typeof(Knight))]
        [TestCase(ChessPieceType.Queen, true, typeof(Queen))]
        [TestCase(ChessPieceType.Queen, false, typeof(Queen))]
        [TestCase(ChessPieceType.Rook, true, typeof(Rook))]
        [TestCase(ChessPieceType.Rook, false, typeof(Rook))]
        [TestCase(ChessPieceType.Bishop, true, typeof(Bishop))]
        [TestCase(ChessPieceType.Bishop, false, typeof(Bishop))]
        [TestCase(ChessPieceType.Pawn, true, typeof(Pawn))]
        [TestCase(ChessPieceType.Pawn, false, typeof(Pawn))]
        public void CanGetCorrectChessPieceForType(ChessPieceType type, bool isWhitePiece, Type expectedType)

        {
            // Act
            ChessPieceBase result = _factory.GetChessPiece(type, isWhitePiece);

            // Assert
            result.Should().BeOfType(expectedType);
            result.IsWhitePiece.Should().Be(isWhitePiece);
        }

        [Test]
        public void GetChessPieceThrowsArgumentOutOfRangeExceptionForInvalidType()
        {
            // Arrange
            var invalidType = (ChessPieceType)99;

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _factory.GetChessPiece(invalidType, true));
            ex.Message.Should().Contain($"Invalid value {invalidType} specified for type");
        }
    }
}