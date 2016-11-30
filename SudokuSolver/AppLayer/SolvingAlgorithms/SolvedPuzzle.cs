using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class SolvedPuzzle : SolvingAlgorithm
    {
        public SolvedPuzzle() { actualType = "SOLVED"; }

        public override bool CheckCell(Cell cell)
        {
            return false;
        }
    }
}
