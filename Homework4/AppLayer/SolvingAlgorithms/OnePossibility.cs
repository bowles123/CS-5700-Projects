using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class OnePossibility : SolvingAlgorithm
    {
        public override void IteratePuzzle()
        {
            foreach (Cell cell in Puzzle)
            {
                if (cell.Value == '_' && cell.Possibilities.Count == 1)
                {
                    UpdateCell(cell, cell.Possibilities[0]);
                    return;
                }
            }
        }
    }
}
