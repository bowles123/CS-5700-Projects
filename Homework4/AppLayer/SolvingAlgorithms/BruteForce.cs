using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class BruteForce : SolvingAlgorithm
    {
        public BruteForce() { actualType = "BRUTE_FORCE"; }

        public override bool CheckCell(Cell cell)
        {
            if (cell.Possibilities.Count == 0) return false;

            Puzzle p = new Puzzle(Puzzle.Rows, Puzzle.Columns, Puzzle.Blocks, Puzzle.Symbols);
            p.OutFile = Puzzle.OutFile;
            p.Blanks = Puzzle.Blanks;

            foreach (Puzzle puzzle in Puzzle.BacktrackingStack)
                p.BacktrackingStack.Push(puzzle);

            cell.Update(cell.Possibilities[0]);
            Puzzle.BacktrackingStack.Push(p);
            return true;
        }
    }
}
