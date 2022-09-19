using Chess;

public abstract class PiecesBase 
{

    public PiecesBase(int piecesId, string piecesName, TeamSideEnum teamSide, PiecesTypeEnum piecesType, PiecesStateEnum piecesState, char icon)
    {
        PiecesId = piecesId;
        PiecesName = piecesName;
        TeamSide = teamSide;
        PiecesType = piecesType;
        PiecesState = piecesState;
        Icon = icon;
    }

    public char Icon { get; set; }
    public int PiecesId { get; set; }
    public string PiecesName { get; set; }
    public bool isFirstMove = true;
    public TeamSideEnum TeamSide { get; set; }
    public PiecesTypeEnum PiecesType { get; set; }
    public PiecesStateEnum PiecesState { get; set; }




    /// <summary>
    ///فرمول مکان های قابل دسترس مهره
    /// </summary>
    public abstract Func<Location, List<PieceHouse> , List<PiecesBase>, List<Location>> AvailablePointFormula { get; }


    public void GoOut() => PiecesState = PiecesStateEnum.Outed;
    public void isMove() => isFirstMove = false;
    public ConsoleColor GetColor()
    {
        var enumType = typeof(TeamSideEnum);
        var memberInfos =
        enumType.GetMember(TeamSide.ToString());
        var enumValueMemberInfo = memberInfos.FirstOrDefault(m =>
        m.DeclaringType == enumType);
        var valueAttributes =
        enumValueMemberInfo?.GetCustomAttributes(typeof(TeamInfoAttribute), false);
        var color = ((TeamInfoAttribute)valueAttributes[0]).Color;
        return color;
    }

}

