using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.SudokuComponents
{
    public class Column: Component
    {
        internal Column(int id) : base(id) { ActualType = "COLUMN"; }

        public override void Update(Subject cell)
        {
            throw new NotImplementedException();
        }
    }
}
