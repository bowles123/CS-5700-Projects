using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class Column: Component
    {
        internal Column(int id) : base(id) { }
        internal Column(int id, List<Cell> cells) : base(id, cells) { }
    }
}
