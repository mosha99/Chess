 
public class UnauthorizedMovementException : Exception
{
    public UnauthorizedMovementException() : base("The piece cannot go to this point") { }
}
public class PieceOutedExceptione : Exception
{
    public PieceOutedExceptione() : base("This piece is not in the game") { }
}
public class EndOfLoop : Exception
{
    public EndOfLoop() : base("Loop End") { }
}
public class OutOfMenue : Exception
{
    public OutOfMenue() : base("User Out this menue") { }
}