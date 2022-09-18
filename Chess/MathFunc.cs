namespace Chess;

public static class MathFunc
{
    public static double GetDistanceBetweenTwoLocation(Location location1 , Location location2)
    {
        int YDistance = Math.Abs( location1.YLocation - location2.YLocation);
        int XDistance = Math.Abs( location1.XLocation - location2.XLocation);
        double Result = Math.Sqrt(Math.Pow(YDistance, 2) + Math.Pow(XDistance, 2));
        return Result;
    }
}
