using System;
using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class NoPossibilities : SolvingAlgorithm
    {
        public override void IteratePuzzle()
        {
            foreach (Cell cell in Puzzle)
            {
                if (cell.Value == '_' && cell.Possibilities == null)
                {
                    throw new Exception("Cell with no possibilities.");
                }
                return;
            }
        }
    }
}
