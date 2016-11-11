using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.SudokuComponents
{
    public class Block: Component
    {
        internal Block(int id) : base(id) { ActualType = "BLOCK"; }

        public override void Update(Subject cell)
        {
            throw new NotImplementedException();
        }
    }
}
