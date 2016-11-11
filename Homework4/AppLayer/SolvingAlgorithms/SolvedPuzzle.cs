using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.SolvingAlgorithms
{
    public class SolvedPuzzle : SolvingAlgorithm
    {
        public override void IteratePuzzle()
        {
            base.IteratePuzzle(); // Change
        }

        public override void UpdateCell()
        {
            throw new InvalidOperationException();
        }
    }
}
