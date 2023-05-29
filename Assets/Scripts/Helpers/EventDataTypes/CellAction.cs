namespace Helpers.Events
{

    public struct CellAction : IGridPosition
    {
        public int x { get; set; }
        public int z { get; set; }
        public bool ToRemove { get; set; }
        public bool AllClear { get; set; }

        public CellAction(int x, int z)
        {
            this.x = x;
            this.z = z;
            this.ToRemove = false;
            this.AllClear = false;  
        }
    }
}
