using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class Block: Component
    {
        internal Block(int id) : base(id) { }
        internal Block(int id, List<Cell> cells) : base(id, cells) { }
    }
}
