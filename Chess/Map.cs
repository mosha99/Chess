
internal class Map
{
    public readonly List<PiecesBase> DuringPieces = new List<PiecesBase>();
    public readonly List<PieceHouse> Pieces = new List<PieceHouse>();

    private EventHandler OnChangePiecesLocation;
    internal Map(EventHandler onChangePiecesLocation)
    {
        OnChangePiecesLocation = onChangePiecesLocation;
    }

    private void RemoveHouse(int PieceId)
    {
        var House = Pieces.SingleOrDefault(x => x.PieceId == PieceId);
        if (House != null)
            Pieces.Remove(House);
    }
    private void RemoveHouse(Location location)
    {
        var House = Pieces.SingleOrDefault(x => x.location.Equals(location));
        if (House != null)
            Pieces.Remove(House);
    }
    public PiecesBase? GetPiecesByLocation(Location location)
    {
        var House = Pieces.SingleOrDefault(x => x.location.Equals(location));

        if (House == null) return null;

        var result = DuringPieces.Single(x => House.PieceId == x.PiecesId && x.PiecesState == PiecesStateEnum.During);

        return result;
    }
    public Location? GetLocationByPieces(int PieceId)
    {
        var House = Pieces.SingleOrDefault(x => x.PieceId == PieceId);

        return House?.location;
    }
    public Dictionary<int, Location> GetAvailablePoint(int piecesId)
    {
        var Piece = DuringPieces.Single(pieces => pieces.PiecesId == piecesId);

        List<Location> Result = new List<Location>();

        if (Piece.PiecesState == PiecesStateEnum.Outed)
            throw new PieceOutedExceptione();

        Location thisPieceLocation = GetLocationByPieces(piecesId);

        var points = Piece.AvailablePointFormula(thisPieceLocation, Pieces, DuringPieces);

        Result.AddRange(points);

        int i = 1;
        var DictionaryResult = Result.ToDictionary(location => i++);

        return DictionaryResult;
    }
    public void Print()
    {
        Console.Clear();
        for (int x = 0; x <= 8; x++)
        {
            Console.Write($"  {x}\t");
            for (int y = 1; y <= 8; y++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (x == 0)
                {
                    Console.Write(y);

                }
                else
                {
                    int? PiecesId = Pieces.SingleOrDefault(ph => ph.location.Equals(x, y))?.PieceId;
                    if (PiecesId == null) Console.Write('_');
                    else
                    {
                        var Piece = DuringPieces.Single(x => x.PiecesId == PiecesId);
                        piecesPrint(Piece);

                    }
                }

                Console.Write('\t');
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

        DuringPieces
            .Where(x => x.PiecesState == PiecesStateEnum.Outed)
            .GroupBy(x => x.TeamSide).ToList()
            .ForEach(x =>
            {
                Console.Write($" {x.Key.ToString()}  :"); x.ToList().ForEach(p =>
                {
                    Console.Write(' ');
                    piecesPrint(p);
                });
                Console.WriteLine();
            });
    }

    private void piecesPrint(PiecesBase Piece)
    {
        Console.ForegroundColor = Piece.GetColor();
        Console.Write(Piece.Icon);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void AddDuringPieces(PiecesBase piecesBase, Location location)
    {
        if (DuringPieces.Any(x => x.PiecesId == piecesBase.PiecesId)) throw new Exception("Id is Uniq");

        DuringPieces.Add(piecesBase);

        Pieces.Add(new PieceHouse() { location = location, PieceId = piecesBase.PiecesId });
    }
    public void ChangePiecesLocation(int PiecesId, Location TothisLocation)
    {

        CleanTargetLocation(TothisLocation);

        CleanNowLocation(PiecesId);

        SetPiecesForLocation(PiecesId, TothisLocation);

        OnChangePiecesLocation.Invoke(null, null);
    }
    private void CleanTargetLocation(Location location)
    {
        GetPiecesByLocation(location)?.GoOut();
        RemoveHouse(location);
    }
    private void CleanNowLocation(int PiecesId)
    {
        RemoveHouse(PiecesId);
    }
    private void SetPiecesForLocation(int piecesId, Location tothisLocation)
    {
        DuringPieces.Single(p => p.PiecesId == piecesId).isMove();

        Pieces.Add(new PieceHouse()
        {
            PieceId = piecesId,
            location = tothisLocation
        });

    }
}
