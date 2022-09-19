
namespace Chess;

public class Knight : PiecesBase
{

    public Knight(int piecesId, string piecesName, TeamSideEnum teamSide)
        : base(piecesId, piecesName, teamSide, PiecesTypeEnum.Knight, PiecesStateEnum.During, 'K')
    {
    }

    public override Func<Location, List<PieceHouse>, List<PiecesBase>, List<Location>> AvailablePointFormula =>
        (Location, Map, PiecesList) =>
        {
            var Results = new List<Location>();



            int[] numbers = { 1, -1, 2, -2 };


            foreach (int i in numbers)
            {
                foreach (int j in numbers)
                {
                    if (Math.Abs(i) == Math.Abs(j)) continue;
                    try
                    {
                        var loc = new Location(Location.XLocation + i, Location.YLocation + j);
                        Results.Add(loc);
                    }
                    catch (ArgumentOutOfRangeException Aoex)
                    {
                    }


                }
            }


            Results =
            Results
            .Where(x => 
                !Map.Any(p =>
                    p.location.Equals(x) &&
                    PiecesList.Single(y => y.PiecesId == p.PieceId).TeamSide == TeamSide
                  )
            ).ToList();


            return Results;
        };






}
