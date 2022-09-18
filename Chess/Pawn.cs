
namespace Chess
{
    public class Pawn : PiecesBase
    {

        public Pawn(int piecesId, string piecesName, TeamSideEnum teamSide)
            : base(piecesId, piecesName, teamSide, PiecesTypeEnum.Pawn, PiecesStateEnum.During, 'P')
        {
        }

        public override Func<Location, List<PieceHouse>, List<PiecesBase>, List<Location>> AvailablePointFormula =>
            (Location, Map, PiecesList) =>
            {
                var Results = new List<Location>();

                var enemiPiesec = GetAvailblePointInAttackMode(Location, Map, PiecesList);

                Results.AddRange(enemiPiesec);

                var moveAvilbleHoseLocations = GetAvailblePointInMoveMode(Location, Map, PiecesList);

                Results.AddRange(moveAvilbleHoseLocations);

                return Results;
            };





        public List<Location> GetAvailblePointInMoveMode(Location location, List<PieceHouse> Map, List<PiecesBase> PiecesList)
        {
         
            var enemiPiesec = new List<Location>();

            Location firstHouse = new Location(location.XLocation, location.YLocation + (int)TeamSide);

            int? firstHousePiecesid = Map.SingleOrDefault(p => p.location.Equals(firstHouse))?.PieceId;

            if (firstHousePiecesid != null)  goto Out; 

            enemiPiesec.Add(firstHouse);

            if(isFirstMove == false) goto Out; 

            Location secendHouse = new Location(firstHouse.XLocation, firstHouse.YLocation + (int)TeamSide);

            int? secendHousePiecesid = Map.SingleOrDefault(p => p.location.Equals(firstHouse))?.PieceId;

            if (secendHousePiecesid != null )  goto Out; 

            enemiPiesec.Add(secendHouse);


            Out:
            return enemiPiesec;
        }
        public List<Location> GetAvailblePointInAttackMode(Location location, List<PieceHouse> Map, List<PiecesBase> PiecesList)
        {
            var locNextLeft = new Location(location.XLocation + 1, location.YLocation + (int)TeamSide);
            var locNextRight = new Location(location.XLocation - 1, location.YLocation + (int)TeamSide);

            var enemiPiesec = Map
            .Where(p => p.location.Equals(locNextLeft) || p.location.Equals(locNextRight))
            .Where(p => PiecesList.Single(x => x.PiecesId == p.PieceId).TeamSide != TeamSide)
            .Select(p => p.location).ToList();

            return enemiPiesec;
        }


    }
}
