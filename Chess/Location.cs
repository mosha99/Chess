 
public class Location
{
    public Location(int xLocation, int yLocation)
    {
        if (!(xLocation >= 1 && xLocation <= 8)) throw new ArgumentOutOfRangeException(" X Outed Of Range");
        if (!(yLocation >= 1 && yLocation <= 8)) throw new ArgumentOutOfRangeException(" Y Outed Of Range");

        XLocation = xLocation;
        YLocation = yLocation;
    }

    public int XLocation { get;private set; }
    public int YLocation { get;private set; }

    public bool Equals(Location obj)
    {
        bool YEqual = this.YLocation == obj.YLocation;
        bool XEqual = this.XLocation == obj.XLocation;
        bool Equals = XEqual && YEqual;

        return Equals;
    }   
    public bool Equals(int x ,int y)
    {
        bool YEqual = this.YLocation == x;
        bool XEqual = this.XLocation == y;
        bool Equals = XEqual && YEqual;

        return Equals;
    }
    public override string ToString()
    {
        return XLocation+" "+YLocation;
    }

}
