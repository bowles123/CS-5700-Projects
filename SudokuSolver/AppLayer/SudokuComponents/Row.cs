using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class Row: Component
    {
        internal Row(int id) : base(id) { }
        internal Row(int id, List<Cell> cells) : base(id, cells) { }
    }
}
