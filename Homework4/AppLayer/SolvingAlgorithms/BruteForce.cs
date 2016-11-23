using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class BruteForce : SolvingAlgorithm
    {
        public BruteForce() { actualType = "BRUTE_FORCE"; }

        public override bool CheckCell(Cell cell)
        {
            if (cell.Possibilities.Count == 0) return false;

            char val = cell.Possibilities[0];
            cell.RemovePossibility(val);
            Puzzle p = Puzzle.Clone();

            cell.Update(val);
            Puzzle.BacktrackingStack.Push(p);
            return true;
        }
    }
}
