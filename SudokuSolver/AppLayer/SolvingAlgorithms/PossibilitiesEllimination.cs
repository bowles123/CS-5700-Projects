using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class PossibilitiesEllimination : SolvingAlgorithm
    {
        public override void IteratePuzzle()
        {
            foreach (Cell cell in Puzzle)
            {
                if (cell.Value.Equals('_'))
                {
                    foreach (char possibility in cell.Possibilities)
                    {
                        if (!Puzzle.Rows[cell.X].Contains(possibility) &&
                            !Puzzle.Columns[cell.Y].Contains(possibility) &&
                            !Puzzle.Blocks[cell.B].Contains(possibility))
                        {
                            UpdateCell(cell, possibility);
                            return;
                        }
                    }
                }
            }
        }
    }
}
