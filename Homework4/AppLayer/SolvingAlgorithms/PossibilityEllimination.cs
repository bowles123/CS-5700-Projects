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
                if (!Puzzle.Rows[cell.X].Contains(possibility) &&
                    !Puzzle.Columns[cell.Y].Contains(possibility) &&
                    !Puzzle.Blocks[cell.B].Contains(possibility))
                {
                    UpdateCell(cell, possibility);
                    return true;
                }
            }
            return false;
        }
    }
}
