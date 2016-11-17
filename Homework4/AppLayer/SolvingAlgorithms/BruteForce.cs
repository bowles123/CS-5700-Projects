using AppLayer.SudokuComponents;
using System.Collections.Generic;

namespace AppLayer.SolvingAlgorithms
{
    public class BruteForce : SolvingAlgorithm
    {
        public BruteForce() { actualType = "BRUTE_FORCE"; }

        public override bool CheckCell(Cell cell)
        {
            cell.Update(cell.Possibilities[0]);
            Puzzle.BacktrackingStack.Push(Puzzle);
            return true;
        }
    }
}
