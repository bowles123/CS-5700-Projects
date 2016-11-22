using System.Collections.Generic;
using AppLayer.SudokuComponents;
using AppLayer.SolvingAlgorithms;

namespace SudokuSolver
{
    public class Solver
    {
        public List<SolvingAlgorithm> Techniques { get; set; }
        public Puzzle Puzzle { get; set; }

        public bool Solve()
        {
            if (Puzzle.Solve(Techniques))
            {
                Puzzle.WriteOutPuzzle();
                return true;
            }
            return false;
        }
    }
}
