namespace Helpers.Events
{

    public struct CellAction : IGridPosition
    {
        public int x { get; set; }
        public int z { get; set; }
        public bool isSelected;

        public CellAction(int x, int z)
        {
            this.x = x;
            this.z = z;
            this.isSelected = false;
        }
    }
}