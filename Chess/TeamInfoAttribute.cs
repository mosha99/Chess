namespace Chess;

[System.AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
sealed class TeamInfoAttribute : Attribute
{


    public ConsoleColor Color;

    public TeamInfoAttribute(ConsoleColor color)
    {
        Color = color;
    }


}