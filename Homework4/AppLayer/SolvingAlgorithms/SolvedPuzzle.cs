using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class SolvedPuzzle : SolvingAlgorithm
    {
        public override void IteratePuzzle()
        {
            foreach (Cell cell in Puzzle)
            {
                if (cell.Value == '_')
                {
                    Puzzle.SolvingAlgorithm = new NoPossibilities();
                    Puzzle.SolvingAlgorithm.Start();
                    return;
                }
            }

            Puzzle.Solved = (BruteForce.BacktrackingStack.Count == 0);
        }
    }
}
