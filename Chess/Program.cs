
using Chess;
public class Program
{
    public static List<PiecesBase> DuringPieces = new List<PiecesBase>();

    public static void Main()
    {
        ChessField chessField = new ChessField();
        chessField.StartGame();

        Console.Read();

    }
}
