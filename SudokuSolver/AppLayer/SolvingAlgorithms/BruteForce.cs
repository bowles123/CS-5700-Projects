using AppLayer.SudokuComponents;
using System.Collections.Generic;

namespace AppLayer.SolvingAlgorithms
{
    public class BruteForce : SolvingAlgorithm
    {
        public Stack<Puzzle> BacktrackingStack { get; set; }
        public BruteForce() { actualType = "BRUTE_FORCE"; }

        public override bool CheckCell(Cell cell)
        {
            if (cell.Possibilities.Count == 0) return false;

            char val = cell.Possibilities[0];
            cell.RemovePossibility(val);
            cell.Update(val);

            BacktrackingStack.Push(Puzzle.Clone());
            return true;
        }
    }
}
