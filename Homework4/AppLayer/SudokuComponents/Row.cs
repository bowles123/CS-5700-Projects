using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.SudokuComponents
{
    public class Row: Component
    {
        internal Row(int id) : base(id) { ActualType = "ROW"; }

        public override void Update(Subject cell)
        {
            throw new NotImplementedException();
        }
    }
}
