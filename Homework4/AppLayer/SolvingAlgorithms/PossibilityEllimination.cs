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
                if (!Puzzle.Rows[cell.Y - 1].ContainsPossibility(possibility, cell.X, cell.Y) ||
                    !Puzzle.Columns[cell.X - 1].ContainsPossibility(possibility, cell.X, cell.Y) ||
                    !Puzzle.Blocks[cell.B - 1].ContainsPossibility(possibility, cell.X, cell.Y))
                {
                    UpdateCell(cell, possibility);
                    Puzzle.Blanks--;
                    return true;
                }
            }
            return false;
        }
    }
}
