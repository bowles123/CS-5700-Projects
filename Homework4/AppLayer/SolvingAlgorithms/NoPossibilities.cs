using System;
using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class NoPossibilities : SolvingAlgorithm
    {
        public override void IteratePuzzle()
        {
            base.IteratePuzzle(); // Change
        }

        public override void UpdateCell(Cell cell)
        {
            throw new Exception("Unsolvable puzzle.");
        }
    }
}
