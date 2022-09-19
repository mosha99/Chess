
namespace Chess;

public class Bishop : PiecesBase
{


    public Bishop(int piecesId, string piecesName, TeamSideEnum teamSide)
        : base(piecesId, piecesName, teamSide, PiecesTypeEnum.Bishop, PiecesStateEnum.During, 'B')
    {
    }

    public override Func<Location, List<PieceHouse>, List<PiecesBase>, List<Location>> AvailablePointFormula =>
        (Location, Map, PiecesList) =>
        {
            var Results = new List<Location>();


            var Line1 = GetAvailbelPointByLine(1, 1, Location);
            var Line2 = GetAvailbelPointByLine(1, -1, Location);
            var Line3 = GetAvailbelPointByLine(-1, 1, Location);
            var Line4 = GetAvailbelPointByLine(-1, -1, Location);

            Action<Location> Locationaction = p =>
            {
                int? result = Map.FirstOrDefault(x => x.location.Equals(p))?.PieceId;

                if (result == null)
                {
                    Results.Add(p);
                }
                else if (PiecesList.Single(x => x.PiecesId == result).TeamSide != TeamSide)
                {
                    Results.Add(p);
                    throw new EndOfLoop();
                }
                else
                {
                    throw new EndOfLoop();

                }

            };

            try
            {
                Line1.ForEach(Locationaction);
            }
            catch (EndOfLoop) { }   
            try
            {
                Line2.ForEach(Locationaction);
            }
            catch (EndOfLoop) { }  
            try
            {
                Line3.ForEach(Locationaction);
            }
            catch (EndOfLoop) { }  
            try
            {
                Line4.ForEach(Locationaction);
            }
            catch (EndOfLoop) { }

            return Results;
        };

    public List<Location> GetAvailbelPointByLine(int XaddSixe, int YaddSixe, Location StartLocation)
    {
        var Result = new List<Location>();
        var baseLoc = StartLocation;

        try
        {
            while (true)
            {
                StartLocation = new Location(StartLocation.XLocation + XaddSixe, StartLocation.YLocation + YaddSixe);
                Result.Add(StartLocation);
            }
        }
        catch (ArgumentOutOfRangeException) { }

        return Result;
    }

}
