public struct GridPosition
{
    public int x;
    public int z;

    public GridPosition(int x, int y)
    {
        this.x = x;
        this.z = y;
    }
    public override string ToString()
    {
        return string.Format("({0},{1})", x, z);
    }
}