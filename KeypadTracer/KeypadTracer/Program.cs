using KeypadTracer;
using KeypadTracer.ChessPieces;
using Microsoft.Extensions.DependencyInjection;


var host = Startup.CreateHostBuilder(args).Build();

var keypad = host.Services.GetRequiredService<IKeypadTracer>();
var chessPieceFactory = host.Services.GetRequiredService<IChessPieceFactory>();


Console.WriteLine("Bishop Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Bishop, isWhitePiece: false)));

Console.WriteLine("Rook Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Rook, isWhitePiece: false)));

Console.WriteLine("King Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.King, isWhitePiece: false)));

Console.WriteLine("Queen Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Queen, isWhitePiece: false)));

Console.WriteLine("Knight Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Knight, isWhitePiece: false)));

Console.WriteLine("Pawn Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Pawn, isWhitePiece: false)));


Console.WriteLine("White Bishop Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Bishop, isWhitePiece: true)));

Console.WriteLine("White Rook Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Rook, isWhitePiece: true)));

Console.WriteLine("White King Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.King, isWhitePiece: true)));

Console.WriteLine("White Queen Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Queen, isWhitePiece: true)));

Console.WriteLine("White Knight Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Knight, isWhitePiece: true)));

Console.WriteLine("White Pawn Count");

Console.WriteLine(keypad.GetValidPhoneNumberCombinationCount(chessPieceFactory.GetChessPiece(ChessPieceType.Pawn, isWhitePiece: true)));

Console.ReadLine();