using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class PossibilityEllimination : SolvingAlgorithm
    {
        public PossibilityEllimination() { actualType = "POSSIBILITY_ELLIMINATION"; }

        public override bool CheckCell(Cell cell)
        {
            foreach (char possibility in cell.Possibilities)
            {
                if (!Puzzle.Rows[cell.Y - 1].Contains(possibility) &&
                    !Puzzle.Columns[cell.X - 1].Contains(possibility) &&
                    !Puzzle.Blocks[cell.B - 1].Contains(possibility))
                {
                    UpdateCell(cell, possibility);
                    Puzzle.Invalid = true;
                    return true;
                }
            }
            return false;
        }
    }
}
