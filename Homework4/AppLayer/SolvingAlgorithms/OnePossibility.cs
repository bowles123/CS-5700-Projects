using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class OnePossibility : SolvingAlgorithm
    {
        public override void IteratePuzzle()
        {
            base.IteratePuzzle(); // Change
        }

        public override void UpdateCell(Cell cell)
        {

        }
    }
}
