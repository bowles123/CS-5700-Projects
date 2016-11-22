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
            Puzzle.BacktrackingStack.Push(Puzzle);

            while (Puzzle.BacktrackingStack.Count > 0 && Puzzle.Solutions < 2)
            {
                if (Puzzle.BacktrackingStack.Count > 0)
                    Puzzle = Puzzle.BacktrackingStack.Pop();

                if (Puzzle.Solve(Techniques))
                {
                    Puzzle.WriteOutPuzzle();
                }

                if (Puzzle.Invalid) return false;
            }

            if (Puzzle.Solutions >= 2)
                return false;
            return true;
        }
    }
}
