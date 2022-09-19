
using Chess;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

public class Program
{
    public static void Main()
    {
        ChessField chessField = new ChessField();
        chessField.StartGame();
        Console.Read();
    }
}

