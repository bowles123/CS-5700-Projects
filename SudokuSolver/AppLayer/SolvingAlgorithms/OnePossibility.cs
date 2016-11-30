using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class OnePossibility : SolvingAlgorithm
    {
        public OnePossibility() { actualType = "ONE_POSSIBILITY"; }

        public override bool CheckCell(Cell cell)
        {
            if (cell.Possibilities.Count == 1)
            {
                UpdateCell(cell, cell.Possibilities[0]);
                Puzzle.Blanks--;
                return true;
            }

            return false;
        }
    }
}
