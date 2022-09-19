

using Chess;
/// <summary>
/// Singeltone Class For ChessField
/// </summary>
public class ChessField
{
    private Map map;

    private event EventHandler ResetMap;

    public void StartGame()
    {
        ResetMap += RestartMap;
        InitializeGame();
        map.Print();
        StartQuestion();
    }

    private void RestartMap(object? sender, EventArgs e)
    {
        map.Print();
    }

    private void InitializeGame()
    {
        map = new Map(ResetMap);

        #region initializaChessField

        map.AddDuringPieces(new Pawn(12, "p1", TeamSideEnum.up), new Location(1, 2));
        map.AddDuringPieces(new Pawn(11, "p2", TeamSideEnum.up), new Location(2, 2));
        map.AddDuringPieces(new Pawn(13, "p3", TeamSideEnum.up), new Location(3, 2));
        map.AddDuringPieces(new Pawn(14, "p4", TeamSideEnum.up), new Location(4, 2));
        map.AddDuringPieces(new Pawn(15, "p5", TeamSideEnum.up), new Location(5, 2));
        map.AddDuringPieces(new Pawn(16, "p6", TeamSideEnum.up), new Location(6, 2));
        map.AddDuringPieces(new Pawn(17, "p7", TeamSideEnum.up), new Location(7, 2));
        map.AddDuringPieces(new Pawn(18, "p8", TeamSideEnum.up), new Location(8, 2));


        map.AddDuringPieces(new Knight(22, "S1", TeamSideEnum.up), new Location(1, 1));
        map.AddDuringPieces(new Knight(21, "S2", TeamSideEnum.up), new Location(2, 1));
        map.AddDuringPieces(new Knight(23, "S3", TeamSideEnum.up), new Location(3, 1));
        map.AddDuringPieces(new Knight(24, "S4", TeamSideEnum.up), new Location(4, 1));
        map.AddDuringPieces(new Bishop(25, "B5", TeamSideEnum.up), new Location(5, 1));
        map.AddDuringPieces(new Bishop(26, "B6", TeamSideEnum.up), new Location(6, 1));
        map.AddDuringPieces(new Bishop(27, "B7", TeamSideEnum.up), new Location(7, 1));
        map.AddDuringPieces(new Bishop(28, "B8", TeamSideEnum.up), new Location(8, 1));



        map.AddDuringPieces(new Pawn(41, "p1", TeamSideEnum.down), new Location(1, 7));
        map.AddDuringPieces(new Pawn(42, "p2", TeamSideEnum.down), new Location(2, 7));
        map.AddDuringPieces(new Pawn(43, "p3", TeamSideEnum.down), new Location(3, 7));
        map.AddDuringPieces(new Pawn(44, "p4", TeamSideEnum.down), new Location(4, 7));
        map.AddDuringPieces(new Pawn(45, "p5", TeamSideEnum.down), new Location(5, 7));
        map.AddDuringPieces(new Pawn(46, "p6", TeamSideEnum.down), new Location(6, 7));
        map.AddDuringPieces(new Pawn(47, "p7", TeamSideEnum.down), new Location(7, 7));
        map.AddDuringPieces(new Pawn(48, "p8", TeamSideEnum.down), new Location(8, 7));


        map.AddDuringPieces(new Knight(52, "S1", TeamSideEnum.down), new Location(1, 8));
        map.AddDuringPieces(new Knight(51, "S2", TeamSideEnum.down), new Location(2, 8));
        map.AddDuringPieces(new Knight(53, "S3", TeamSideEnum.down), new Location(3, 8));
        map.AddDuringPieces(new Knight(54, "S4", TeamSideEnum.down), new Location(4, 8));
        map.AddDuringPieces(new Bishop(55, "B5", TeamSideEnum.down), new Location(5, 8));
        map.AddDuringPieces(new Bishop(56, "B6", TeamSideEnum.down), new Location(6, 8));
        map.AddDuringPieces(new Bishop(57, "B7", TeamSideEnum.down), new Location(7, 8));
        map.AddDuringPieces(new Bishop(58, "B8", TeamSideEnum.down), new Location(8, 8));

        #endregion
    }

    private void StartQuestion()
    {
        while (true)
        {
            try
            {
                Console.WriteLine();

                Console.WriteLine("- Quit by Enter 0 In Evry Question");
                Console.Write("- Enter Location Like 23 ('x = 2 & y = 3') For select And Move Pieces : ");
                string answer = Console.ReadLine();
                if (int.Parse(answer) == 0) throw new OutOfMenue();
                var x = int.Parse(answer[0].ToString());
                var y = int.Parse(answer[1].ToString());
                Location location;
                try
                {
                    location = new Location(x, y);

                    Location answerLocation = PrintAvailbleLocationForPieces(location);

                    int? PiecesId = map.GetPiecesByLocation(location)?.PiecesId;

                    if (PiecesId == null) throw new Exception("Pieces Not Find");

                    map.ChangePiecesLocation(PiecesId.Value, answerLocation);

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
            catch (OutOfMenue)
            {
                ResetMap.Invoke(null, null);
                continue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }

    }

    private Location PrintAvailbleLocationForPieces(Location location)
    {
        int? PiecesId = map.GetPiecesByLocation(location)?.PiecesId;
        if (PiecesId == null) throw new Exception("Not Found");
        var pointList = map.GetAvailablePoint(PiecesId.Value);

        Console.WriteLine("Available Point For This Pieces");

        foreach (var item in pointList)
        {
            Console.WriteLine($"{item.Key} - x : {item.Value.XLocation}  y: {item.Value.YLocation}");
        }


        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.Write("- Enter Location Id : ");
                string answerLocation = Console.ReadLine();
                if (int.Parse(answerLocation) == 0) throw new OutOfMenue();
                var id = int.Parse(answerLocation[0].ToString());

                if (pointList[id] == null) continue;

                return pointList[id];
            }
            catch (OutOfMenue ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

            }
        }
    }

}
