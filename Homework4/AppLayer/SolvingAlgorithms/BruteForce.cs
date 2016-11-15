using AppLayer.SudokuComponents;
using System.Collections.Generic;

namespace AppLayer.SolvingAlgorithms
{
    public class BruteForce : SolvingAlgorithm
    {
        private Stack<Cell> backtrackingStack;

        public Stack<Cell> BacktrackingStack { get { return backtrackingStack; } }
        public BruteForce() { }

        public override void IteratePuzzle()
        {
            base.IteratePuzzle(); // Change
        }

        public override void UpdateCell(Cell cell)
        {
            base.UpdateCell(cell); // Change
        }
    }
}
