
public class ChangePiecesLocationArgs:EventArgs
{
    public int PiecesId { get; set; }
    public Location ToLocation { get; set; }
}
