using System.Collections.Generic;
using AppLayer.SudokuComponents;
using AppLayer.SolvingAlgorithms;

namespace SudokuSolver
{
    public class Solver
    {
        public List<SolvingAlgorithm> Techniques { get; set; }
        public Stack<Puzzle> BacktrackingStack { get; set; }
        public Puzzle Puzzle { get; set; }
        public Solver() { BacktrackingStack = new Stack<Puzzle>(); }

        public bool Solve()
        {
            foreach (SolvingAlgorithm technique in Techniques)
            {
                if (technique is BruteForce)
                {
                    BruteForce algorithm = technique as BruteForce;
                    algorithm.BacktrackingStack = BacktrackingStack;
                    break;
                }
            }

            BacktrackingStack.Push(Puzzle);

            while (BacktrackingStack.Count > 0 && Puzzle.Solutions < 2)
            {
                if (BacktrackingStack.Count > 0)
                    Puzzle = BacktrackingStack.Pop();

                if (Puzzle.Solve(Techniques))
                {
                    Puzzle.WriteOutPuzzle();
                }

                if (Puzzle.Invalid) return false;
            }

            if (Puzzle.Solutions >= 2)
                return false;
            if (Puzzle.Solved)
                return true;
            return false;
        }
    }
}
