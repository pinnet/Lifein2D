public struct GridPosition : IGridPosition
{
    public int x { get; set; }
    public int z { get; set; }

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
    // add a comparison operator to compare two GridPositions
    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return (a.x == b.x) && (a.z == b.z);
    }
    public override bool Equals(object obj)
    {
        if (obj is GridPosition)
        {
            GridPosition other = (GridPosition)obj;
            return (this == other);
        }
        return false;
    }
    // add a comparison operator to compare two GridPositions
    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }
    public override int GetHashCode()
    {
        return x.GetHashCode() ^ z.GetHashCode();
    }
    public override string ToString()
    {
        return string.Format("({0},{1})", x, z);
    }
}