using AppLayer.SudokuComponents;
using System;

namespace AppLayer.SolvingAlgorithms
{
    public class NoPossibilities : SolvingAlgorithm
    {
        public NoPossibilities() { actualType = "NO_POSSIBILITIES"; }

        public override bool CheckCell(Cell cell)
        {
            if (cell.Possibilities == null)
            {
                Console.WriteLine("Invalid Puzzle:\nCell with no possibilities.");
                return true;
            }

            return false;
        }
    }
}
