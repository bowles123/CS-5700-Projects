using AppLayer.SudokuComponents;
using System;

namespace AppLayer.SolvingAlgorithms
{
    public class NoPossibilities : SolvingAlgorithm
    {
        public NoPossibilities() { actualType = "NO_POSSIBILITIES"; }

        public override bool CheckCell(Cell cell)
        {
            if (cell.Possibilities == null || cell.Possibilities.Count == 0 &&
                Puzzle.BacktrackingStack.Count == 0) 
            {
                Puzzle.Invalid = true;
                Console.WriteLine("Invalid Puzzle:\nCell with no possibilities.");
            }

            return false;
        }
    }
}
