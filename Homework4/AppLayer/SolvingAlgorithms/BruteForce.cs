using AppLayer.SudokuComponents;
using System.Collections.Generic;

namespace AppLayer.SolvingAlgorithms
{
    public class BruteForce : SolvingAlgorithm
    {
        private static Stack<Cell> backtrackingStack = new Stack<Cell>();

        public static Stack<Cell> BacktrackingStack { get { return backtrackingStack; } }
        public BruteForce() { }

        public override void IteratePuzzle()
        {
            foreach (Cell cell in Puzzle)
            {
                if (cell.Value.Equals('_'))
                {
                    cell.Update(cell.Possibilities[0]);
                    backtrackingStack.Push(cell);
                }
            }
        }
    }
}
